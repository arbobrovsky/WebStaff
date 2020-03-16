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
    public class DepatrmentService
    {
        private readonly DataManager _dataManager;

        public DepatrmentService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task SaveToDb(DepartmentViewModel model)
        {
            await _dataManager.Departments.SaveDepartment(new Department { Name = model.Name });
        }
        public async Task<List<DepartmentViewModel>> DepartmentViewModels()
        {
            var dbModel = await _dataManager.Departments.GetDepartments();
            var result = new List<DepartmentViewModel>();
            foreach (var item in dbModel)
            {
                result.Add(new DepartmentViewModel {DepartmentId=item.DepartmentId, Name=item.Name});
            }
            return result;
        }
    }
}
