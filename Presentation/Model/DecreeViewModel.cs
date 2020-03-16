
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Presentation.Model
{
    public class DecreeViewModel
    {
        public int DecreeId { get; set; }
        public string DecreeNumber { get; set; }
        public DateTime DecreeTime { get; set; }
        public bool Active { get; set; }
        public IEnumerable<DecreeStaffsViewModel> DecreeStaffsViewModel { get; set; }

        public DecreeViewModel()
        {
            DecreeStaffsViewModel = new List<DecreeStaffsViewModel>();
        }
    }


    public class DecreeStaffsViewModel
    {

        public int DecreeStaffsId { get; set; }
        public int DecreeId { get; set; }
        public string Type { get; set; }
        public DecreeViewModel Decree { get; set; }
        public int StaffId { get; set; }
        public int? FiredId { get; set; }
        public FiredViewModel FiredViewModel { get; set; }
    }

}