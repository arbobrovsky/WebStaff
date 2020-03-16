using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPositionRepository
    {
        IEnumerable<Position> GetPositions();
        Task<Position> GetPositionById(int positionId);
        Task SavePosition(Position position);
        void DeletePosition(Position position);
    }
}
