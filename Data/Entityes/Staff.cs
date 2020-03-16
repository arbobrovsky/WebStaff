using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int RankId { get; set; }
        public virtual Rank Rank { get; set; }
        public int SubDepartmenId { get; set; }
        public virtual SubDepartment SubDepartmen { get; set; }
        public bool Fired { get; set; } 
    }
}
