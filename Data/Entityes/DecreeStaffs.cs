using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
   public class DecreeStaffs
    {

        public int DecreeStaffsId { get; set; }
        public int DecreeId { get; set; }
        public string Type { get; set; }
        public Decree Decree { get; set; }
        public int StaffId { get; set; }
        public int? FiredId { get; set; }
        public Fired Fired { get; set; }
    }
}
