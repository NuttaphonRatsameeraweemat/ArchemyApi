using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Archemy.MasterData.Bll.Models
{
    public class AreaViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string AreaName { get; set; }
    }
}
