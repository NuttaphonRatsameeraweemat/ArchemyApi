using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.MasterData.Bll.Models
{
    public class AccountSubTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubTypeName { get; set; }
    }
}
