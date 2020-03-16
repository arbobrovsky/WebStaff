using BusinessLogic.Interfaces;
using Data;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private readonly EFDBContext _context;

        public EFDepartmentRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteDepartment(Department department)
        {
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public async Task<Department> GetDepartmentById(int? departmentId)
        {

            return await _context.Departments.FirstOrDefaultAsync(x=>x.DepartmentId==departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {//
            return await _context.Departments.ToListAsync();
           // await _context.Set<Department>().Include(x => x.SubDepartments).AsNoTracking().ToListAsync();
        }

        public async Task SaveDepartment(Department department)
        {
            if (department.DepartmentId == 0)
            {
                _context.Departments.Add(department);
            }
            else
            {
                _context.Entry(department).State = EntityState.Modified;
            }
           await _context.SaveChangesAsync();
        }

      
    }
}
