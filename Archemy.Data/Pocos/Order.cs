using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Order
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
