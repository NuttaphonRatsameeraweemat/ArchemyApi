using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.MasterData.Bll.Models
{
    public class AccountTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }
    }
}
