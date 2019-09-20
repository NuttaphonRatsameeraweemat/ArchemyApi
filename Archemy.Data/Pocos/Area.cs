using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Area
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(150)]
        public string AreaName { get; set; }
    }
}
