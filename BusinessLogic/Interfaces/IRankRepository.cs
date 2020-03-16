using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
   public interface IRankRepository
    {
        Task<IEnumerable<Rank>> GetRanks();
        Task<Rank> GetRankById(int RankId);
        Task SaveRank(Rank rank);
        void DeleteRank(Rank rank);
    }
}
