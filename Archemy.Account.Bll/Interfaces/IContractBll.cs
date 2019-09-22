using Archemy.Account.Bll.Models;
using Archemy.Helper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Interfaces
{
    public interface IContractBll
    {
        /// <summary>
        /// Get Contract list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContractViewModel> GetList(int accountId);
        /// <summary>
        /// Get Detail of Contract item.
        /// </summary>
        /// <param name="id">The identity of Contract.</param>
        /// <returns></returns>
        ContractViewModel GetDetail(int id);
        /// <summary>
        /// Insert new Contract item.
        /// </summary>
        /// <param name="model">The Contract information value.</param>
        /// <returns></returns>
        ResultViewModel Save(ContractViewModel model);
        /// <summary>
        /// Update Contract item.
        /// </summary>
        /// <param name="model">The ContractType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(ContractViewModel model);
        /// <summary>
        /// Remove Contract item.
        /// </summary>
        /// <param name="accountId">The identity of Contract.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
