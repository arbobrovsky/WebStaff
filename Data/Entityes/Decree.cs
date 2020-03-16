using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Decree
    {
        public int DecreeId { get; set; }
        public string DecreeNumber { get; set; }
        public DateTime DecreeTime { get; set; }
        public bool Active { get; set; }
        public IEnumerable<DecreeStaffs> DecreeStaffs { get; set; }

        public Decree()
        {
            DecreeStaffs = new List<DecreeStaffs>();
        }
    }
}
