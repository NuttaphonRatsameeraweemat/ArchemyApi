using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Employee.Bll.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeTypeName { get; set; }
    }
}
