using BusinessLogic;
using Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ServicesManager
    {
        private readonly DataManager _dataManager;

        private readonly DepatrmentService _depatrmentService;
        private readonly FiredService _firedService;
        private readonly PositionService _positionService;
        private readonly RankService _rankService;
        private readonly StaffService _staffService;
        private readonly SubDepartmentService _subDepartmentService;
        private readonly DecreeService _decreeService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _depatrmentService = new DepatrmentService(_dataManager);
            _firedService = new FiredService(_dataManager);
            _positionService = new PositionService(_dataManager);
            _rankService = new RankService(_dataManager);
            _staffService = new StaffService(_dataManager);
            _subDepartmentService = new SubDepartmentService(_dataManager);
            _decreeService = new DecreeService(_dataManager);
        }

        public DepatrmentService Depatrment { get { return _depatrmentService; } }
        public FiredService Fired { get { return _firedService; } }
        public PositionService Position { get { return _positionService; } }
        public RankService Rank { get { return _rankService; } }
        public StaffService Staff { get { return _staffService; } }
        public SubDepartmentService SubDepartment { get { return _subDepartmentService; } }
        public DecreeService DecreeService { get { return _decreeService;  } }
    }

   
}
