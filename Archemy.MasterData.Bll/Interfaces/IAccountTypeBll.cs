using Archemy.Helper.Models;
using Archemy.MasterData.Bll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.MasterData.Bll.Interfaces
{
    public interface IAccountTypeBll
    {
        /// <summary>
        /// Get AccountType list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccountTypeViewModel> GetList();
        /// <summary>
        /// Get Detail of AccountType item.
        /// </summary>
        /// <param name="id">The identity of AccountType.</param>
        /// <returns></returns>
        AccountTypeViewModel GetDetail(int id);
        /// <summary>
        /// Insert new AccountType item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        ResultViewModel Save(AccountTypeViewModel model);
        /// <summary>
        /// Update AccountType item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(AccountTypeViewModel model);
        /// <summary>
        /// Remove AccountType item.
        /// </summary>
        /// <param name="id">The identity of AccountType.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
