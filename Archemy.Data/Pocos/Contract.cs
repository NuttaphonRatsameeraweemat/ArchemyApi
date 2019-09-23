using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Contract
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        [StringLength(150)]
        public string MainContract { get; set; }
        [Column("Contract")]
        [StringLength(150)]
        public string Contract1 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
    }
}
