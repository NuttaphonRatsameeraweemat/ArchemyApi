using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Authentication.Bll.Models
{
    public class LoginResponseViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
