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
        /// Validate contract is submit or saveDraft.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        bool IsSubmit(int contractId);
        /// <summary>
        /// Validate contract is null or not.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        bool IsNotNull(int contractId);
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
        ResultViewModel Save(ContractViewModel model, string status);
        /// <summary>
        /// Update Contract item.
        /// </summary>
        /// <param name="model">The ContractType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(ContractViewModel model, string status);
        /// <summary>
        /// Remove Contract item.
        /// </summary>
        /// <param name="accountId">The identity of Contract.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
