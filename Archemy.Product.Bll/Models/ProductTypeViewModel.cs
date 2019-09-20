using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Product.Bll.Models
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ProductTypeName { get; set; }
    }
}
