using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class RankViewModel
    {
        public int RankId { get; set; }
        [Display(Name = "Звание")]
        public string Name { get; set; }
    }
}
