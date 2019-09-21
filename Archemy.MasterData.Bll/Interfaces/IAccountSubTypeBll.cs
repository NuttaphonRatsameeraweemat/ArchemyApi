using Archemy.Helper.Models;
using Archemy.MasterData.Bll.Models;
using System.Collections.Generic;

namespace Archemy.MasterData.Bll.Interfaces
{
    public interface IAccountSubTypeBll
    {
        /// <summary>
        /// Get AccountSubType list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccountSubTypeViewModel> GetList();
        /// <summary>
        /// Get Detail of AccountSubType item.
        /// </summary>
        /// <param name="id">The identity of AccountSubType.</param>
        /// <returns></returns>
        AccountSubTypeViewModel GetDetail(int id);
        /// <summary>
        /// Insert new AccountSubType item.
        /// </summary>
        /// <param name="model">The AccountSubType information value.</param>
        /// <returns></returns>
        ResultViewModel Save(AccountSubTypeViewModel model);
        /// <summary>
        /// Update AccountSubType item.
        /// </summary>
        /// <param name="model">The AccountSubType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(AccountSubTypeViewModel model);
        /// <summary>
        /// Remove AccountSubType item.
        /// </summary>
        /// <param name="id">The identity of AccountSubType.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
