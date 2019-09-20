using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Password
    {
        [Column("EmpID")]
        public int EmpId { get; set; }
        [Column("Password")]
        public byte[] Password1 { get; set; }
    }
}
