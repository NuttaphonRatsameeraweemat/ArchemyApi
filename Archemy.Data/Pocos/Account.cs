using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archemy.Data.Pocos
{
    public partial class Account
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(200)]
        public string AccountName { get; set; }
        [StringLength(20)]
        public string PhoneNo { get; set; }
        public string Website { get; set; }
        [Column("TypeID")]
        public int? TypeId { get; set; }
        [Column("SubTypeID")]
        public int? SubTypeId { get; set; }
        [Column("AreaID")]
        public int? AreaId { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
    }
}
