using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class PositionService
    {
        private readonly DataManager _dataManager;

        public PositionService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
