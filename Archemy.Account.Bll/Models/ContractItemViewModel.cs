using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class ContractItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ContractPrince { get; set; }
    }
}
