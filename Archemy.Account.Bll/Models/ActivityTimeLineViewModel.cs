using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class ActivityTimeLineViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ActivityComment { get; set; }
    }
}
