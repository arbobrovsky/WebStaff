using BusinessLogic;
using Data.Entityes;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class SubDepartmentService
    {
        private readonly DataManager _dataManager;
        public SubDepartmentService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task SaveToDbSubDepartment(SubDepartmentViewModel subDepartment)
        {
            await _dataManager.SubDepartment.SaveSubDepartment(new SubDepartment { Name = subDepartment.Name, DepartmentId = subDepartment.DepartmentId });
        }


        public async Task<SubDepartmentViewModel> CreateSubDepartmentViewModel()
        {
            var result = new SubDepartmentViewModel();
            var departmens = new List<DepartmentViewModel>();
            foreach (var item in await _dataManager.Departments.GetDepartments())
            {
                departmens.Add(new DepartmentViewModel { DepartmentId = item.DepartmentId, Name = item.Name });
            }
            result.Departments = departmens;

            return result;
        }

        public async Task<List<SubDepartmentViewModel>> SubDepartmentList()
        {
            var subDepartments = await _dataManager.SubDepartment.GetSubDepartment();
            var result = new List<SubDepartmentViewModel>();
            var departmens = new DepartmentViewModel();


            foreach (var item in subDepartments)
            {
                var departFromDb = await _dataManager.Departments.GetDepartmentById(item.DepartmentId);
                result.Add(new SubDepartmentViewModel
                {
                    SubDepartmentId = item.SubDepartmentId,
                    Name = item.Name,
                    DepartmentId = item.DepartmentId,
                    Department = new DepartmentViewModel { DepartmentId = departFromDb.DepartmentId, Name = departFromDb.Name }
                });
            }
            return result;
        }

        public async Task<List<SubDepartmentsList>> GetSubDepartmentsLists(int departmentId)
        {
            var subDepartmentsList = await _dataManager.SubDepartment.GetSubDepartment();
            var result = new List<SubDepartmentsList>();
            foreach (var item in subDepartmentsList.Where(x => x.DepartmentId == departmentId))
            {
                result.Add(new SubDepartmentsList
                {
                    DepartmentId = item.DepartmentId,
                    Name = item.Name,
                    SubDepartmentId = item.SubDepartmentId
                });
            }

            return result;
        }

    }
}
