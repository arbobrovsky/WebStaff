using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class PositionViewModel
    {
        public int positionId { get; set; }
        [Display(Name = "Должность")]
        public string Name { get; set; }
    }
}
