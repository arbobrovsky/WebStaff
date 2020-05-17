using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetStaffs();
        Task<Staff> GetStaffById(int staffId);
        Task SaveStaff(Staff staff);
        void DeleteStaff(Staff staff);
    }
}
