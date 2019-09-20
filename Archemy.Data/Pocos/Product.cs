using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Product
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(250)]
        public string ProductName { get; set; }
        [Column("ProductTypeID")]
        public int? ProductTypeId { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal? Prince1 { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal? Prince2 { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal? Prince3 { get; set; }
        [StringLength(40)]
        public string Unit { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
    }
}
