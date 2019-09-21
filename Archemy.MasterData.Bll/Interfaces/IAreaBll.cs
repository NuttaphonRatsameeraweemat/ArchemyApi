using Archemy.Helper.Models;
using Archemy.MasterData.Bll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.MasterData.Bll.Interfaces
{
    public interface IAreaBll
    {
        /// <summary>
        /// Get Area list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AreaViewModel> GetList();
        /// <summary>
        /// Get Detail of Area item.
        /// </summary>
        /// <param name="id">The identity of Area.</param>
        /// <returns></returns>
        AreaViewModel GetDetail(int id);
        /// <summary>
        /// Insert new Area item.
        /// </summary>
        /// <param name="model">The Area information value.</param>
        /// <returns></returns>
        ResultViewModel Save(AreaViewModel model);
        /// <summary>
        /// Update Area item.
        /// </summary>
        /// <param name="model">The Area information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(AreaViewModel model);
        /// <summary>
        /// Remove Area item.
        /// </summary>
        /// <param name="id">The identity of Area.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
