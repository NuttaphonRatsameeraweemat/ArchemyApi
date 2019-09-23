using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
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
    public class ActivityTimeLineBll : IActivityTimeLineBll
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
        /// Initializes a new instance of the <see cref="ActivityTimeLineBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public ActivityTimeLineBll(IUnitOfWork unitOfWork, IMapper mapper, IManageToken token)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _token = token;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Activity TimeLine list with account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        public IEnumerable<ActivityTimeLineViewModel> GetList(int accountId)
        {
            var result = new List<ActivityTimeLineViewModel>();
            var data = _unitOfWork.GetRepository<ActivityTimeLine>().Get(x => x.AccountId == accountId, x => x.OrderByDescending(y => y.ActivityDate));
            var empList = _unitOfWork.GetRepository<Employee>().GetCache();

            foreach (var item in data)
            {
                var temp = empList.FirstOrDefault(x => x.Id == item.EmpId);
                result.Add(new ActivityTimeLineViewModel
                {
                    Id = item.Id,
                    AccountId = item.AccountId.Value,
                    ActivityBy = string.Format(ConstantValue.EmpTemplate, temp?.FirstName, temp?.LastName),
                    ActivityDate = item.ActivityDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    ActivityComment = item.ActivityComment
                });
            }

            return result;
        }

        /// <summary>
        /// Insert new Activity TimeLine item.
        /// </summary>
        /// <param name="model">The ActivityTimeLine information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(ActivityTimeLineViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var activityTimeLine = _mapper.Map<ActivityTimeLineViewModel, Data.Pocos.ActivityTimeLine>(model);
                activityTimeLine.EmpId = _token.EmpId;
                activityTimeLine.ActivityDate = DateTime.Now;
                _unitOfWork.GetRepository<Data.Pocos.ActivityTimeLine>().Add(activityTimeLine);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Update Activity TimeLine item.
        /// </summary>
        /// <param name="model">The Activity TimeLine information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(ActivityTimeLineViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var activityTimeLine = _unitOfWork.GetRepository<Data.Pocos.ActivityTimeLine>().GetById(model.Id);
                activityTimeLine.ActivityComment = model.ActivityComment;
                _unitOfWork.GetRepository<Data.Pocos.ActivityTimeLine>().Update(activityTimeLine);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Remove Activity TimeLine item.
        /// </summary>
        /// <param name="id">The identity of Activity TimeLine.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var activityTimeLine = _unitOfWork.GetRepository<Data.Pocos.ActivityTimeLine>().GetById(id);
                _unitOfWork.GetRepository<Data.Pocos.ActivityTimeLine>().Remove(activityTimeLine);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        #endregion

    }
}
