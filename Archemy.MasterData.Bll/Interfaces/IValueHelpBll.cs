using Archemy.MasterData.Bll.Models;
using System.Collections.Generic;

namespace Archemy.MasterData.Bll.Interfaces
{
    public interface IValueHelpBll
    {
        /// <summary>
        /// Get ValueHelp List by type.
        /// </summary>
        /// <param name="type">The type of value.</param>
        /// <returns></returns>
        IEnumerable<ValueHelpViewModel> Get(string type);
    }
}
