using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISubDepartmentRepository
    {
        Task<IEnumerable<SubDepartment>> GetSubDepartment();
        Task<SubDepartment> GetSubDepartmentById(int departmentId);
        Task SaveSubDepartment(SubDepartment department);
        void DeletSubDepartment(SubDepartment department);
    }
}
