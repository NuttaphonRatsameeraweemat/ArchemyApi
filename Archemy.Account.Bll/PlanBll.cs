using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper;
using Archemy.Helper.Components;
using Archemy.Helper.Interfaces;
using Archemy.Helper.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Archemy.Account.Bll
{
    public class PlanBll : IPlanBll
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
        /// <summary>
        /// The ClaimsIdentity in token management.
        /// </summary>
        private readonly IManageToken _token;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public PlanBll(IUnitOfWork unitOfWork, IMapper mapper, IManageToken token)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _token = token;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Plan list with account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        public IEnumerable<PlanViewModel> GetList(int accountId)
        {
            var result = new List<PlanViewModel>();
            var data = _unitOfWork.GetRepository<Plan>().Get(x => x.AccountId == accountId, x => x.OrderByDescending(y => y.EndDate));
            var empList = _unitOfWork.GetRepository<Employee>().GetCache();

            foreach (var item in data)
            {
                var temp = empList.FirstOrDefault(x => x.Id == item.CreateBy);
                result.Add(new PlanViewModel
                {
                    Id = item.Id,
                    AccountId = item.AccountId.Value,
                    CreateBy = item.CreateBy.Value,
                    CreateByName = string.Format(ConstantValue.EmpTemplate, temp?.FirstName, temp?.LastName),
                    StartDate = item.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    EndDate = item.EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ss")
                });
            }

            return result;
        }

        /// <summary>
        /// Insert new Plan item.
        /// </summary>
        /// <param name="model">The Plan information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(PlanViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var plan = _mapper.Map<PlanViewModel, Plan>(model);
                plan.CreateBy = _token.EmpId;
                plan.StartDate = UtilityService.ConvertToDateTime(model.StartDate, ConstantValue.DateTimeFormat);
                plan.EndDate = UtilityService.ConvertToDateTime(model.EndDate, ConstantValue.DateTimeFormat);
                _unitOfWork.GetRepository<Plan>().Add(plan);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Update Plan item.
        /// </summary>
        /// <param name="model">The Plan information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(PlanViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var plan = _unitOfWork.GetRepository<Plan>().GetById(model.Id);
                plan.PlanName = model.PlanName;
                plan.StartDate = UtilityService.ConvertToDateTime(model.StartDate, ConstantValue.DateTimeFormat);
                plan.EndDate = UtilityService.ConvertToDateTime(model.EndDate, ConstantValue.DateTimeFormat);
                _unitOfWork.GetRepository<Plan>().Update(plan);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Remove Plan item.
        /// </summary>
        /// <param name="id">The identity of Plan.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var plan = _unitOfWork.GetRepository<Plan>().GetById(id);
                _unitOfWork.GetRepository<Plan>().Remove(plan);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        #endregion

    }
}
