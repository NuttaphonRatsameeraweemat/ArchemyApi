using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class AccountProductSellViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Unit { get; set; }
    }
}
