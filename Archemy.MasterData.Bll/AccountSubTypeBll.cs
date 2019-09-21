using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Models;
using Archemy.MasterData.Bll.Interfaces;
using Archemy.MasterData.Bll.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Archemy.MasterData.Bll
{
    public class AccountSubTypeBll : IAccountSubTypeBll
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
        /// Initializes a new instance of the <see cref="AccountSubTypeBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public AccountSubTypeBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get AccountSubType list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountSubTypeViewModel> GetList()
        {
            return _mapper.Map<IEnumerable<AccountSubType>, IEnumerable<AccountSubTypeViewModel>>(
                   _unitOfWork.GetRepository<AccountSubType>().GetCache());
        }

        /// <summary>
        /// Get Detail of AccountSubType item.
        /// </summary>
        /// <param name="id">The identity of AccountSubType.</param>
        /// <returns></returns>
        public AccountSubTypeViewModel GetDetail(int id)
        {
            return _mapper.Map<AccountSubType, AccountSubTypeViewModel>(
                   _unitOfWork.GetRepository<AccountSubType>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// Insert new AccountSubType item.
        /// </summary>
        /// <param name="model">The AccountSubType information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(AccountSubTypeViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountSubType = _mapper.Map<AccountSubTypeViewModel, AccountSubType>(model);
                _unitOfWork.GetRepository<AccountSubType>().Add(accountSubType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountSubType();
            return result;
        }

        /// <summary>
        /// Update AccountSubType item.
        /// </summary>
        /// <param name="model">The AccountSubType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(AccountSubTypeViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountSubType = _unitOfWork.GetRepository<AccountSubType>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                accountSubType.SubTypeName = model.SubTypeName;
                _unitOfWork.GetRepository<AccountSubType>().Update(accountSubType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountSubType();
            return result;
        }

        /// <summary>
        /// Remove AccountSubType item.
        /// </summary>
        /// <param name="id">The identity of AccountSubType.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var AccountSubType = _unitOfWork.GetRepository<AccountSubType>().GetById(id);
                _unitOfWork.GetRepository<AccountSubType>().Remove(AccountSubType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountSubType();
            return result;
        }

        /// <summary>
        /// Reload Cache when AccountSubType is change.
        /// </summary>
        private void ReloadCacheAccountSubType()
        {
            _unitOfWork.GetRepository<AccountSubType>().ReCache();
        }

        #endregion

    }
}
