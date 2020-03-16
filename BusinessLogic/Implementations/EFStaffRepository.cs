using BusinessLogic.Interfaces;
using Data;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class EFStaffRepository : IStaffRepository
    {
        private readonly EFDBContext _context;

        public EFStaffRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteStaff(Staff staff)
        {
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                _context.SaveChanges();
            }
        }

        public async Task<Staff> GetStaffById(int staffId)
        {
            return await _context.Staffs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.StaffId == staffId);
            //  return null;
        }

        public IEnumerable<Staff> GetStaffs()
        {
            return _context.Staffs.ToList();
            // return null;
        }

        public async Task SaveStaff(Staff staff)
        {
            if (staff.StaffId == 0)
            {
                await _context.Staffs.AddAsync(staff);
            }
            else
            {
                _context.Entry(staff).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
    }
}
