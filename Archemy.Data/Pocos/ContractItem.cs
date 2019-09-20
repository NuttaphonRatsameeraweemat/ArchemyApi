using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class ContractItem
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ContractID")]
        public int? ContractId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }
        [Column(TypeName = "numeric(8,2)")]
        public decimal? ContractPrince { get; set; }
    }
}
