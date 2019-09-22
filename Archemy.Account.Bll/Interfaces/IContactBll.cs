using Archemy.Account.Bll.Models;
using Archemy.Helper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Interfaces
{
    public interface IContactBll
    {
        /// <summary>
        /// Get Contact list with account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        IEnumerable<ContactViewModel> GetListByAccount(int accountId);
        /// <summary>
        /// Insert new Contact item.
        /// </summary>
        /// <param name="model">The Contact information value.</param>
        /// <returns></returns>
        ResultViewModel Save(ContactViewModel model);
        /// <summary>
        /// Update Contact item.
        /// </summary>
        /// <param name="model">The ContactType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(ContactViewModel model);
        /// <summary>
        /// Remove Contact item.
        /// </summary>
        /// <param name="id">The identity of Contact.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
