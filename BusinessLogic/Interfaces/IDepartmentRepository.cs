using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entityes;

namespace BusinessLogic.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
       Task< Department> GetDepartmentById(int? departmentId);
        Task SaveDepartment(Department department);
        void DeleteDepartment(Department department);
    }
}
