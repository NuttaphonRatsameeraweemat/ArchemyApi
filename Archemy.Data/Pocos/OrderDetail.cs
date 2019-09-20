using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class OrderDetail
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal? Prince { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal? PerPrince { get; set; }
        public int? Quantity { get; set; }
    }
}
