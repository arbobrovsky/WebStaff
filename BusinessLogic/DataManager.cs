using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DataManager
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFiredRepository _firedRepository;
        private readonly IPositionRepository _positiondRepository;
        private readonly IRankRepository _rankRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly ISubDepartmentRepository _subDepartmentRepository;
        private readonly IDecreeRepository _decreeRepository;

        public DataManager(
            IDepartmentRepository departmentRepository,
            IFiredRepository firedRepository,
            IPositionRepository positiondRepository,
            IRankRepository rankRepository,
            IStaffRepository staffRepository,
            ISubDepartmentRepository subDepartmentRepository,
            IDecreeRepository decreeRepository
            )
        {
            _departmentRepository = departmentRepository;
            _firedRepository = firedRepository;
            _positiondRepository = positiondRepository;
            _rankRepository = rankRepository;
            _staffRepository = staffRepository;
            _subDepartmentRepository = subDepartmentRepository;
            _decreeRepository = decreeRepository;
        }

        public IDepartmentRepository Departments { get { return _departmentRepository; } }
        public IFiredRepository Fired { get { return _firedRepository; } }
        public IPositionRepository Positiond { get { return _positiondRepository; } }
        public ISubDepartmentRepository SubDepartment { get { return _subDepartmentRepository; } }
        public IRankRepository Rank { get { return _rankRepository; } }
        public IStaffRepository Staff { get { return _staffRepository; } }
        public IDecreeRepository Decree { get { return _decreeRepository; } }
    }
}
