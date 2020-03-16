using BusinessLogic;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entityes;
namespace Presentation.Services
{
    public class FiredService
    {
        private readonly DataManager _dataManager;

        public FiredService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task GetOut(StaffViewModel model)
        {
            await _dataManager.Fired.SaveFired(new Fired { FiredTime = model.HowTimeFired, HowFired = model.HowFired, StaffId = model.StaffId });
            var staff = await _dataManager.Staff.GetStaffById(model.StaffId);
            staff.Fired = true;
            await _dataManager.Staff.SaveStaff(staff);
        }
    }
}
