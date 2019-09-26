using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class ContractViewModel
    {
        public ContractViewModel()
        {
            ContractItems = new List<ContractItemViewModel>();
        }

        public int Id { get; set; }
        [Required]
        public int? AccountId { get; set; }
        [MaxLength(150)]
        public string MainContract { get; set; }
        [MaxLength(150)]
        public string Contract1 { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public string Status { get; set; }

        public List<ContractItemViewModel> ContractItems { get; set; }
    }
}
