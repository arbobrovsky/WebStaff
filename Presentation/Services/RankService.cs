using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class RankService
    {
        private readonly DataManager _dataManager;

        public RankService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
