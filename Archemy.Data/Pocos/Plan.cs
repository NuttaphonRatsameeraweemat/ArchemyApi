using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Plan
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CreateBy { get; set; }
        [StringLength(200)]
        public string PlanName { get; set; }
    }
}
