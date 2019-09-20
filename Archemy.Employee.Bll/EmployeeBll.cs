using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Employee.Bll.Interfaces;
using Archemy.Employee.Bll.Models;
using Archemy.Helper.Components;
using Archemy.Helper.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Archemy.Employee.Bll
{
    public class EmployeeBll : IEmployeeBll
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
        /// Initializes a new instance of the <see cref="EmployeeBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        public EmployeeBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Employee List.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeViewModel> GetList()
        {
            var data = _mapper.Map<IEnumerable<Data.Pocos.Employee>, IEnumerable<EmployeeViewModel>>(
                _unitOfWork.GetRepository<Data.Pocos.Employee>().GetCache());
            var valueHelp = _unitOfWork.GetRepository<ValueHelp>().GetCache(x => x.ValueType == ConstantValue.ValueTypeEmployeeType);
            foreach (var item in data)
            {
                var temp = valueHelp.FirstOrDefault(x => x.ValueKey == item.EmployeeType);
                item.EmployeeTypeName = temp?.ValueText;
            }
            return data;
        }

        /// <summary>
        /// Get Employee detail with employee identity.
        /// </summary>
        /// <returns></returns>
        public EmployeeViewModel GetDetail(int id)
        {
            return _mapper.Map<Data.Pocos.Employee, EmployeeViewModel>(
                _unitOfWork.GetRepository<Data.Pocos.Employee>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// The Method insert employee information.
        /// </summary>
        /// <param name="formData">The employee data.</param>
        public ResultViewModel Update(EmployeeViewModel formData)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var data = _mapper.Map<EmployeeViewModel, Data.Pocos.Employee>(formData);
                _unitOfWork.GetRepository<Data.Pocos.Employee>().Update(data);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Reload cache when register action.
        /// </summary>
        private void ReloadCacheEmployee()
        {
            _unitOfWork.GetRepository<Data.Pocos.Employee>().ReCache();
        }

        #endregion

    }
}
