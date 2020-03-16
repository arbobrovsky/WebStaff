using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Fired
    {
        public int FiredId { get; set; }

        public string HowFired { get; set; }
        public DateTime FiredTime { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

    }
}
