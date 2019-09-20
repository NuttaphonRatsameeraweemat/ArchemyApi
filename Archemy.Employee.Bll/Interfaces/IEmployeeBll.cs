using Archemy.Employee.Bll.Models;
using Archemy.Helper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Employee.Bll.Interfaces
{
    public interface IEmployeeBll
    {
        /// <summary>
        /// Get Employee List.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeViewModel> GetList();
        /// <summary>
        /// Get Employee detail with employee identity.
        /// </summary>
        /// <returns></returns>
        EmployeeViewModel GetDetail(int id);
        /// <summary>
        /// The Method insert employee information.
        /// </summary>
        /// <param name="formData">The employee data.</param>
        ResultViewModel Edit(EmployeeViewModel formData);
    }
}
