using BusinessLogic.Interfaces;
using Data;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class EFPositionRepository : IPositionRepository
    {
        private readonly EFDBContext _context;

        public EFPositionRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeletePosition(Position position)
        {
            if (position != null)
            {
                _context.Positions.Remove(position);
                _context.SaveChanges();
            }
           
        }

        public async Task<Position> GetPositionById(int positionId)
        {
            return await _context.Positions.FindAsync(positionId);
        }

        public IEnumerable<Position> GetPositions()
        {
            return _context.Positions.ToList();
        }

        public async Task SavePosition(Position position)
        {
            if (position.PositionId == 0)
            {
                _context.Positions.Add(position);
            }
            else
            {
                _context.Entry(position).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
    }
}
