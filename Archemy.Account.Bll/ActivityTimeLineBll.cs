using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Interfaces;
using Archemy.Helper.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
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
            return _mapper.Map<IEnumerable<Data.Pocos.ActivityTimeLine>, IEnumerable<ActivityTimeLineViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.ActivityTimeLine>().Get(x => x.AccountId == accountId));
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
