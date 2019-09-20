using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class AccountType
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(100)]
        public string TypeName { get; set; }
    }
}
