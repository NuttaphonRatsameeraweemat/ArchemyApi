using Archemy.Account.Bll.Models;
using Archemy.Helper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Interfaces
{
    public interface IActivityTimeLineBll
    {
        /// <summary>
        /// Get Activity TimeLine list with account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        IEnumerable<ActivityTimeLineViewModel> GetList(int accountId);
        /// <summary>
        /// Insert new Activity TimeLine item.
        /// </summary>
        /// <param name="model">The ActivityTimeLine information value.</param>
        /// <returns></returns>
        ResultViewModel Save(ActivityTimeLineViewModel model);
        /// <summary>
        /// Update Activity TimeLine item.
        /// </summary>
        /// <param name="model">The Activity TimeLine information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(ActivityTimeLineViewModel model);
        /// <summary>
        /// Remove Activity TimeLine item.
        /// </summary>
        /// <param name="id">The identity of Activity TimeLine.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
