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
    public class EFFiredRepository : IFiredRepository
    {
        private readonly EFDBContext _context;
        public EFFiredRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteFired(Fired Fired)
        {
            if (Fired != null)
            {
                _context.Fireds.Remove(Fired);
                _context.SaveChanges();
            }
        }

        public  IEnumerable<Fired> GetFireds()
        {
            return _context.Fireds.ToList();
        }

        public async Task<Fired> GetFiredById(int firedId)
        {
            return  await _context.Fireds.FindAsync(firedId);
        }

        public async Task SaveFired(Fired Fired)
        {
            if (Fired.FiredId == 0)
            {
              await  _context.Fireds.AddAsync(Fired);
            }
            else
            {
                _context.Entry(Fired).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
    }
}
