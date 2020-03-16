using Data.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class FiredViewModel
    {
        public int FiredId { get; set; }
        [Display(Name ="Время уволнения")]
        public DateTime FiredTime { get; set; }
        public StaffViewModel Staff { get; set; }
        [Display(Name = "Причина увольнения")]
        public string HowFired { get; set; }
    }
}
