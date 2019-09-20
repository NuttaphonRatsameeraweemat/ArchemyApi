using Archemy.Data.Repository.Interfaces;
using Archemy.Employee.Bll.Interfaces;
using Archemy.Employee.Bll.Models;
using Archemy.Data.Pocos;
using Archemy.Helper.Models;
using AutoMapper;
using System.Transactions;
using Archemy.Helper.Components;
using System.Linq;

namespace Archemy.Employee.Bll
{
    public class RegisterBll : IRegisterBll
    {

        #region [Fields]

        /// <summary>
        /// The utilities unit of work for manipulating utilities data in database.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The auto mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        public RegisterBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// The Register new employee function.
        /// </summary>
        /// <param name="formData">The employee data.</param>
        /// <returns></returns>
        public ResultViewModel Register(RegisterViewModel formData)
        {
            var result = ValidateEmail(formData.Email);
            if (!result.IsError)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int empId = this.SaveCustomer(formData);
                    this.SavePassword(formData, empId);
                    scope.Complete();
                }
                this.ReloadCacheRegister();
            }
            return result;
        }

        /// <summary>
        /// The Method insert employee information.
        /// </summary>
        /// <param name="formData">The employee data.</param>
        private int SaveCustomer(RegisterViewModel formData)
        {
            var data = _mapper.Map<RegisterViewModel, Data.Pocos.Employee>(formData);
            _unitOfWork.GetRepository<Data.Pocos.Employee>().Add(data);
            _unitOfWork.Complete();
            return data.Id;
        }

        /// <summary>
        /// The Method insert password employee login.
        /// </summary>
        /// <param name="formData">The employee data.</param>
        private void SavePassword(RegisterViewModel formData, int empId)
        {
            var password = new PasswordGenerator(formData.Password);
            var data = new Password { EmpId = empId, Password1 = password.GetHash() };
            _unitOfWork.GetRepository<Password>().Add(data);
            _unitOfWork.Complete();
        }

        /// <summary>
        /// Validate Email is already have in database or not.
        /// </summary>
        /// <param name="email">The employee email.</param>
        /// <returns></returns>
        public ResultViewModel ValidateEmail(string email)
        {
            var result = new ResultViewModel();
            var data = _unitOfWork.GetRepository<Data.Pocos.Employee>().Get(x => x.Email == email).FirstOrDefault();
            if (data != null)
            {
                result.IsError = true;
                result.Message = MessageValue.EmailAlreadyExist;
            }
            return result;
        }

        /// <summary>
        /// Reload cache when register action.
        /// </summary>
        private void ReloadCacheRegister()
        {
            _unitOfWork.GetRepository<Data.Pocos.Employee>().ReCache();
            _unitOfWork.GetRepository<Password>().ReCache();
        }

        #endregion

    }
}
