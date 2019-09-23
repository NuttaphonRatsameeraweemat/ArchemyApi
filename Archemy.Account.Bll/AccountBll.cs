using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Components;
using Archemy.Helper.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Archemy.Account.Bll
{
    public class AccountBll : IAccountBll
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
        /// The activityTimeLine manager provides activityTimeLine functionality.
        /// </summary>
        private readonly IActivityTimeLineBll _activityTimeLine;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public AccountBll(IUnitOfWork unitOfWork, IMapper mapper, IActivityTimeLineBll activityTimeLine)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activityTimeLine = activityTimeLine;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Account list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountViewModel> GetList()
        {
            var data = _mapper.Map<IEnumerable<Data.Pocos.Account>, IEnumerable<AccountViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.Account>().GetCache());
            var areaList = _unitOfWork.GetRepository<Data.Pocos.Area>().GetCache();
            var accTypeList = _unitOfWork.GetRepository<Data.Pocos.AccountType>().GetCache();
            var accSubTypeList = _unitOfWork.GetRepository<Data.Pocos.AccountSubType>().GetCache();

            foreach (var item in data)
            {
                item.AreaName = areaList.FirstOrDefault(x => x.Id == item.AreaId)?.AreaName;
                item.TypeName = accTypeList.FirstOrDefault(x => x.Id == item.TypeId)?.TypeName;
                item.SubTypeName = accSubTypeList.FirstOrDefault(x => x.Id == item.SubTypeId)?.SubTypeName;
            }

            return data;
        }

        /// <summary>
        /// Get Detail of Account item.
        /// </summary>
        /// <param name="id">The identity of Account.</param>
        /// <returns></returns>
        public AccountViewModel GetDetail(int id)
        {
            return _mapper.Map<Data.Pocos.Account, AccountViewModel>(
                   _unitOfWork.GetRepository<Data.Pocos.Account>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// Insert new Account item.
        /// </summary>
        /// <param name="model">The Account information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(AccountViewModel model)
        {
            var result = new ResultViewModel();
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                var account = _mapper.Map<AccountViewModel, Data.Pocos.Account>(model);
                _unitOfWork.GetRepository<Data.Pocos.Account>().Add(account);
                _unitOfWork.Complete(scope);
                id = account.Id;
            }
            this.ReloadCacheAccount();
            _activityTimeLine.Save(new ActivityTimeLineViewModel { AccountId = id, ActivityComment = ConstantValue.ActCreateAccount });
            return result;
        }

        /// <summary>
        /// Update Account item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(AccountViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var account = _unitOfWork.GetRepository<Data.Pocos.Account>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                account.AccountName = model.AccountName;
                account.PhoneNo = model.PhoneNo;
                account.Website = model.Website;
                account.TypeId = model.TypeId;
                account.SubTypeId = model.SubTypeId;
                account.AreaId = model.AreaId;
                account.Status = model.Status;
                _unitOfWork.GetRepository<Data.Pocos.Account>().Update(account);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccount();
            _activityTimeLine.Save(new ActivityTimeLineViewModel { AccountId = model.Id, ActivityComment = ConstantValue.ActEditAccount });
            return result;
        }

        /// <summary>
        /// Remove Account item.
        /// </summary>
        /// <param name="id">The identity of Account.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var account = _unitOfWork.GetRepository<Data.Pocos.Account>().GetById(id);
                _unitOfWork.GetRepository<Data.Pocos.Account>().Remove(account);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccount();
            return result;
        }

        /// <summary>
        /// Reload Cache when Account is change.
        /// </summary>
        private void ReloadCacheAccount()
        {
            _unitOfWork.GetRepository<Data.Pocos.Account>().ReCache();
        }

        #endregion

    }
}
