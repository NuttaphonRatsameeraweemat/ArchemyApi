using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Order.Bll.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderItems = new List<OrderDetailViewModel>();
        }

        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        public int? EmpId { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<OrderDetailViewModel> OrderItems { get; set; }
    }
}
