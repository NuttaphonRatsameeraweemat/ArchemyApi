using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class PlanViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string PlanName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
    }
}
