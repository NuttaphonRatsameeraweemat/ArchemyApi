using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Contact
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(150)]
        public string ContactName { get; set; }
        [StringLength(150)]
        public string Position { get; set; }
        [StringLength(25)]
        public string ContactNumber { get; set; }
        [StringLength(150)]
        public string WhoesaleSupplier { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
    }
}
