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
    public class DecreeService
    {
        private readonly DataManager _dataManager;
        public DecreeService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }


        public async Task SaveDecree(DecreeViewModel model)
        {
            if (model != null)
            {
                await _dataManager.Decree.SaveDecree(new Decree
                {
                    DecreeId = model.DecreeId,
                    DecreeNumber = model.DecreeNumber,
                    Active = model.Active,
                    DecreeTime = model.DecreeTime
                    // DecreeStaffs = new DecreeStaffsViewModel { }
                });
            }
        }

        public async Task<List<DecreeViewModel>> GetDecreeToList()
        {
            var result = new List<DecreeViewModel>();
            var modelFromDb = await _dataManager.Decree.GetDecrees();
            foreach (var item in modelFromDb)
            {
                result.Add(new DecreeViewModel
                {
                    DecreeId = item.DecreeId,
                    DecreeNumber = item.DecreeNumber,
                    Active = item.Active,
                    DecreeTime = item.DecreeTime
                });
            }

            return result;
        }


    }
}
