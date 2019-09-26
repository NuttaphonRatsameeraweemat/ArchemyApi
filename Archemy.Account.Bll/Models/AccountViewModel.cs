using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string AccountName { get; set; }
        [MaxLength(20)]
        public string PhoneNo { get; set; }
        public string Website { get; set; }
        [Required]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        [Required]
        public int SubTypeId { get; set; }
        public string SubTypeName { get; set; }
        [Required]
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public string StatusName { get; set; }
    }
}
