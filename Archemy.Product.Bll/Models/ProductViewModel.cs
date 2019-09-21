using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Product.Bll.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ImageList = new List<ProductImageViewModel>();
        }

        public int Id { get; set; }
        [MaxLength(250)]
        public string ProductName { get; set; }
        public int? ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public decimal? Prince1 { get; set; }
        public decimal? Prince2 { get; set; }
        public decimal? Prince3 { get; set; }
        [MaxLength(40)]
        public string Unit { get; set; }
        public List<ProductImageViewModel> ImageList { get; set; }
    }

    public class ProductImageViewModel
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
    }

}
