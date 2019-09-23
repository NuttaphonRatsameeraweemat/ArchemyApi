using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Order.Bll.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Required]
        public decimal Prince { get; set; }
        [Required]
        public decimal PerPrince { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
