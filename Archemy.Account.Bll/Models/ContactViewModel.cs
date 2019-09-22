using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.Account.Bll.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
        public int? AccountId { get; set; }
        [Required]
        [MaxLength(150)]
        public string ContactName { get; set; }
        [StringLength(150)]
        public string Position { get; set; }
        [StringLength(25)]
        public string ContactNumber { get; set; }
        [StringLength(150)]
        public string WhoesaleSupplier { get; set; }
    }
}
