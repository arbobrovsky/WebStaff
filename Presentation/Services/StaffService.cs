using BusinessLogic;
using Data.Entityes;
using Presentation.Model;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class StaffService
    {
        private readonly DataManager _dataManager;

        public StaffService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<StaffCreateViewModel> CreateStaff()
        {
            var positions = new List<PositionViewModel>();
            var ranks = new List<RankViewModel>();
            var SubDepartments = new List<SubDepartmentViewModel>();
            foreach (var item in _dataManager.Positiond.GetPositions())
            {
                positions.Add(new PositionViewModel { positionId = item.PositionId, Name = item.Name });
            }
            foreach (var item in await _dataManager.Rank.GetRanks())
            {
                ranks.Add(new RankViewModel { RankId = item.RankId, Name = item.Name });
            }

            foreach (var item in await _dataManager.SubDepartment.GetSubDepartment())
            {
                SubDepartments.Add(new SubDepartmentViewModel { SubDepartmentId = item.SubDepartmentId, Name = item.Name });
            }

            var result = new StaffCreateViewModel { Position = positions, Rank = ranks, SubDepartmen = SubDepartments };

            return result;
        }


        public async Task SaveToDbStaff(StaffCreateViewModel staff)
        {
            var result = new Staff
            {
                First = staff.First,
                Second = staff.Second,
                MiddleName = staff.MiddleName,
                PositionId = staff.PositionId,
                RankId = staff.RankId,
                SubDepartmenId = staff.SubDepartmenId
            };
            await _dataManager.Staff.SaveStaff(result);
        }

        public async Task<List<StaffViewModel>> Staffs(int id)
        {
            var result = new List<StaffViewModel>();
            if (id == 0)
            {
                foreach (var staffItem in _dataManager.Staff.GetStaffs().Where(x => x.SubDepartmenId == id))
                {
                    //await _dataManager.Positiond.GetPositionById(staffItem.PositionId),
                    var positionObj = await _dataManager.Positiond.GetPositionById(staffItem.PositionId);
                    var rankObj = await _dataManager.Rank.GetRankById(staffItem.RankId);
                    var subDepartment = await _dataManager.SubDepartment.GetSubDepartmentById(staffItem.SubDepartmenId);
                    result.Add(new StaffViewModel
                    {
                        StaffId = staffItem.StaffId,
                        First = staffItem.First,
                        Second = staffItem.Second,
                        MiddleName = staffItem.MiddleName,
                        PositionId = staffItem.PositionId,
                        Position = new PositionViewModel { positionId = positionObj.PositionId, Name = positionObj.Name },
                        RankId = staffItem.RankId,
                        Rank = new RankViewModel { RankId = rankObj.RankId, Name = rankObj.Name },
                        SubDepartmenId = staffItem.SubDepartmenId,
                        SubDepartmen = new SubDepartmentViewModel { SubDepartmentId = subDepartment.SubDepartmentId, Name = subDepartment.Name }
                    });
                }
            }
        
            return result;
        }



        public async Task<List<StaffViewModel>> StaffsList()
        {
            var result = new List<StaffViewModel>();
           
                foreach (var staffItem in _dataManager.Staff.GetStaffs())
                {
                    //await _dataManager.Positiond.GetPositionById(staffItem.PositionId),
                    var positionObj = await _dataManager.Positiond.GetPositionById(staffItem.PositionId);
                    var rankObj = await _dataManager.Rank.GetRankById(staffItem.RankId);
                    var subDepartment = await _dataManager.SubDepartment.GetSubDepartmentById(staffItem.SubDepartmenId);
                    result.Add(new StaffViewModel
                    {
                        StaffId = staffItem.StaffId,
                        First = staffItem.First,
                        Second = staffItem.Second,
                        MiddleName = staffItem.MiddleName,
                        PositionId = staffItem.PositionId,
                        Position = new PositionViewModel { positionId = positionObj.PositionId, Name = positionObj.Name },
                        RankId = staffItem.RankId,
                        Rank = new RankViewModel { RankId = rankObj.RankId, Name = rankObj.Name },
                        SubDepartmenId = staffItem.SubDepartmenId,
                        SubDepartmen = new SubDepartmentViewModel { SubDepartmentId = subDepartment.SubDepartmentId, Name = subDepartment.Name }
                    });
            }

            return result;
        }



        public async Task SaveStaffEditToDb(StaffViewModel model)
        {
            var result = new Staff
            {
                StaffId = model.StaffId,
                First = model.First,
                Second = model.Second,
                MiddleName = model.MiddleName,
                PositionId = model.PositionId,
                RankId = model.RankId,
                SubDepartmenId = model.SubDepartmenId,
                Fired = false,
            };

            if (model.Fired == true)
            {
                result.Fired = true;
                var fired = new Fired
                {
                    FiredTime = model.HowTimeFired,
                    HowFired = model.HowFired,
                    StaffId = model.StaffId,
                };
                await _dataManager.Fired.SaveFired(fired);
            }

            await _dataManager.Staff.SaveStaff(result);
        }


        public async Task SaveStaffToDb(StaffCreateViewModel model)
        {
            var result = new Staff
            {
                StaffId = model.StaffId,
                First = model.First,
                Second = model.Second,
                MiddleName = model.MiddleName,
                PositionId = model.PositionId,
                RankId = model.RankId,
                SubDepartmenId = model.SubDepartmenId
            };
            await _dataManager.Staff.SaveStaff(result);
        }

        public async Task<StaffViewModel> GetStaffByIdForViewModel(int StaffId)
        {
            var result = new StaffViewModel();
            var staffItem = await _dataManager.Staff.GetStaffById(StaffId);
            var departments = new List<DepartmentViewModel>();
            var positions = new List<PositionViewModel>();
            var subDepartment = await _dataManager.SubDepartment.GetSubDepartmentById(staffItem.SubDepartmenId);
            var decreeViewModel = new List<DecreeViewModel>();
            foreach (var item in _dataManager.Positiond.GetPositions())
            {
                positions.Add(new PositionViewModel { positionId = item.PositionId, Name = item.Name });
            }
            foreach (var item in await _dataManager.Decree.GetDecrees())
            {
                decreeViewModel.Add(new DecreeViewModel
                {
                    DecreeId = item.DecreeId,
                    DecreeNumber = item.DecreeNumber,
                    Active = item.Active,
                    DecreeTime = item.DecreeTime
                });
            }


            var rankObj = await _dataManager.Rank.GetRankById(staffItem.RankId);

            foreach (var item in await _dataManager.Departments.GetDepartments())
            {
                departments.Add(new DepartmentViewModel { DepartmentId = item.DepartmentId, Name = item.Name });
            }

            result = new StaffViewModel
            {
                StaffId = staffItem.StaffId,
                First = staffItem.First,
                Second = staffItem.Second,
                MiddleName = staffItem.MiddleName,
                PositionId = staffItem.PositionId,
                Positions = positions,
                RankId = staffItem.RankId,
                Rank = new RankViewModel { RankId = rankObj.RankId, Name = rankObj.Name },
                SubDepartmenId = staffItem.SubDepartmenId,
                SubDepartmen = new SubDepartmentViewModel { SubDepartmentId = subDepartment.SubDepartmentId, Name = subDepartment.Name },
                DepartmenId = subDepartment.DepartmentId,
                Departmens = departments,
                DecreeViewModels = decreeViewModel
            };
            return result;
        }

        public async Task<StaffViewModel> GetStaffById(int staffId)
        {
            var staffItem = await _dataManager.Staff.GetStaffById(staffId);
            var result = new StaffViewModel();
            //await _dataManager.Positiond.GetPositionById(staffItem.PositionId),
            var positionObj = await _dataManager.Positiond.GetPositionById(staffItem.PositionId);
            var rankObj = await _dataManager.Rank.GetRankById(staffItem.RankId);
            var subDepartment = await _dataManager.SubDepartment.GetSubDepartmentById(staffItem.SubDepartmenId);

            result = new StaffViewModel
            {
                StaffId = staffItem.StaffId,
                First = staffItem.First,
                Second = staffItem.Second,
                MiddleName = staffItem.MiddleName,
                PositionId = staffItem.PositionId,
                Position = new PositionViewModel { positionId = positionObj.PositionId, Name = positionObj.Name },
                RankId = staffItem.RankId,
                Rank = new RankViewModel { RankId = rankObj.RankId, Name = rankObj.Name },
                SubDepartmenId = staffItem.SubDepartmenId,
                SubDepartmen = new SubDepartmentViewModel { SubDepartmentId = subDepartment.SubDepartmentId, Name = subDepartment.Name }
            };
            return result;
        }

    }
}
