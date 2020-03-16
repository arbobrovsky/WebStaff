using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class SubDepartment
    {
        public int SubDepartmentId { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }

        public virtual List<Staff> Staffs { get; set; }

        public SubDepartment()
        {
            Staffs = new List<Staff>();
        }
    }
}
