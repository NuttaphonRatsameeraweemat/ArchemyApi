using Archemy.Account.Bll.Models;
using Archemy.Helper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Interfaces
{
    public interface IPlanBll
    {
        /// <summary>
        /// Get Plan list with account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        IEnumerable<PlanViewModel> GetList(int accountId);
        /// <summary>
        /// Insert new Plan item.
        /// </summary>
        /// <param name="model">The Plan information value.</param>
        /// <returns></returns>
        ResultViewModel Save(PlanViewModel model);
        /// <summary>
        /// Update Plan item.
        /// </summary>
        /// <param name="model">The Plan information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(PlanViewModel model);
        /// <summary>
        /// Remove Plan item.
        /// </summary>
        /// <param name="id">The identity of Plan.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
