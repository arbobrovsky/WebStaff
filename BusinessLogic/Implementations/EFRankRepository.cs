using BusinessLogic.Interfaces;
using Data;
using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class EFRankRepository : IRankRepository
    {
        private readonly EFDBContext _context;

        public EFRankRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteRank(Rank rank)
        {
            if (rank != null)
            {
                _context.Ranks.Remove(rank);
                _context.SaveChanges();
            }
            
        }

        public async Task<IEnumerable<Rank>> GetRanks()
        {
            return await _context.Ranks.ToListAsync();
        }

        public async Task<Rank> GetRankById(int RankId)
        {
            return await _context.Ranks.FirstOrDefaultAsync(x=>x.RankId==RankId);
        }

        public async Task SaveRank(Rank rank)
        {
            if (rank.RankId == 0)
            {
                await _context.Ranks.AddAsync(rank);
            }
            else
            {
                _context.Entry(rank).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
    }
}
