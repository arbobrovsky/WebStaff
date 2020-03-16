using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<SubDepartment> SubDepartments { get; set; }

        public Department()
        {
            SubDepartments = new List<SubDepartment>();
        }
    }
}
