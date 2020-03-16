using BusinessLogic.Interfaces;
using Data;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class EFSubDepartmentRepository : ISubDepartmentRepository
    {
        private readonly EFDBContext _context;
        public EFSubDepartmentRepository(EFDBContext context)
        {
             _context = context;
        }

        public void DeletSubDepartment(SubDepartment subDepartment)
        {
            if (subDepartment != null)
            {
               // _context.SubDepartments.Remove(subDepartment);
                _context.SaveChanges();
            }
        }

        public async Task<SubDepartment> GetSubDepartmentById(int departmentId)
        {
           return await _context.SubDepartments.AsNoTracking().FirstOrDefaultAsync(x => x.SubDepartmentId == departmentId);
            //return null;
        }

        public async Task<IEnumerable<SubDepartment>> GetSubDepartment()
        {
            return await _context.SubDepartments.ToListAsync();
          //  return null;
        }

        public async Task SaveSubDepartment(SubDepartment department)
        {
            if (department.SubDepartmentId == 0)
            {
                 await _context.SubDepartments.AddAsync(department);
                
            }
            else
            {
                _context.Entry(department).State = EntityState.Modified;
            }
            await  _context.SaveChangesAsync();
        }

       
    }
}
