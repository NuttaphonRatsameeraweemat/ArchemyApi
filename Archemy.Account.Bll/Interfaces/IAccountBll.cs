using Archemy.Account.Bll.Models;
using Archemy.Helper.Models;
using System.Collections.Generic;

namespace Archemy.Account.Bll.Interfaces
{
    public interface IAccountBll
    {
        /// <summary>
        /// Get Account list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccountViewModel> GetList();
        /// <summary>
        /// Get Detail of Account item.
        /// </summary>
        /// <param name="id">The identity of Account.</param>
        /// <returns></returns>
        AccountViewModel GetDetail(int id);
        /// <summary>
        /// Insert new Account item.
        /// </summary>
        /// <param name="model">The Account information value.</param>
        /// <returns></returns>
        ResultViewModel Save(AccountViewModel model);
        /// <summary>
        /// Update Account item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(AccountViewModel model);
        /// <summary>
        /// Remove Account item.
        /// </summary>
        /// <param name="id">The identity of Account.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
        /// <summary>
        /// Get product stat order account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        IEnumerable<AccountProductSellViewModel> GetProductAccountSell(int accountId);
    }
}
