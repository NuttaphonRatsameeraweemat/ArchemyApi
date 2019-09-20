using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class ProductType
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(150)]
        public string ProductTypeName { get; set; }
    }
}
