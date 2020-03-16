using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class SubDepartmentViewModel
    {
        public int SubDepartmentId { get; set; }
      
        public string Name { get; set; }
        public int? DepartmentId { get; set; }

        public virtual List<StaffViewModel> Staffs { get; set; }
        public virtual List<DepartmentViewModel> Departments { get; set; }
        public virtual DepartmentViewModel Department { get; set; }


        public SubDepartmentViewModel()
        {
            Staffs = new List<StaffViewModel>();
        }
    }

    public class SubDepartmentsList
    {
        public int SubDepartmentId { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
    }

  


}
