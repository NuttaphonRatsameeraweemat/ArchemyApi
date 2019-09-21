using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Models;
using Archemy.MasterData.Bll.Interfaces;
using Archemy.MasterData.Bll.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Archemy.MasterData.Bll
{
    public class AccountTypeBll : IAccountTypeBll
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
        /// Initializes a new instance of the <see cref="AccountTypeBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public AccountTypeBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get AccountType list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountTypeViewModel> GetList()
        {
            return _mapper.Map<IEnumerable<AccountType>, IEnumerable<AccountTypeViewModel>>(
                   _unitOfWork.GetRepository<AccountType>().GetCache());
        }

        /// <summary>
        /// Get Detail of AccountType item.
        /// </summary>
        /// <param name="id">The identity of AccountType.</param>
        /// <returns></returns>
        public AccountTypeViewModel GetDetail(int id)
        {
            return _mapper.Map<AccountType, AccountTypeViewModel>(
                   _unitOfWork.GetRepository<AccountType>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// Insert new AccountType item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(AccountTypeViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountType = _mapper.Map<AccountTypeViewModel, AccountType>(model);
                _unitOfWork.GetRepository<AccountType>().Add(accountType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountType();
            return result;
        }

        /// <summary>
        /// Update AccountType item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(AccountTypeViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountType = _unitOfWork.GetRepository<AccountType>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                accountType.TypeName = model.TypeName;
                _unitOfWork.GetRepository<Data.Pocos.AccountType>().Update(accountType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountType();
            return result;
        }

        /// <summary>
        /// Remove AccountType item.
        /// </summary>
        /// <param name="id">The identity of AccountType.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountType = _unitOfWork.GetRepository<AccountType>().GetById(id);
                _unitOfWork.GetRepository<AccountType>().Remove(accountType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountType();
            return result;
        }

        /// <summary>
        /// Reload Cache when AccountType is change.
        /// </summary>
        private void ReloadCacheAccountType()
        {
            _unitOfWork.GetRepository<AccountType>().ReCache();
        }

        #endregion

    }
}
