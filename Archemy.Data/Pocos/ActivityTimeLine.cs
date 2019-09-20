using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class ActivityTimeLine
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        [Column("EmpID")]
        public int? EmpId { get; set; }
        public string ActivityComment { get; set; }
        public DateTime? ActivityDate { get; set; }
    }
}
