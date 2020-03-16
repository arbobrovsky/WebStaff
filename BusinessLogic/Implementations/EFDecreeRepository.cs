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
    public class EFDecreeRepository : IDecreeRepository
    {
        private readonly EFDBContext _context;

        public EFDecreeRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteDecree(Decree decree)
        {
            if (decree != null)
            {
                _context.Decrees.Remove(decree);
                _context.SaveChanges();
            }
        }

        public async Task<Decree> GetDecreeById(int decreeId)
        {
            return await _context.Decrees.AsNoTracking().FirstOrDefaultAsync(x => x.DecreeId == decreeId);

        }

        public async Task<IEnumerable<Decree>> GetDecrees()
        {
            return await _context.Decrees.ToListAsync();

        }

        public async Task SaveDecree(Decree decree)
        {
            if (decree.DecreeId == 0)
            {
                _context.Decrees.Add(decree);
            }
            else
            {
                _context.Entry(decree).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
    }
}