using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entityes;

namespace BusinessLogic.Interfaces
{
    public interface IDecreeRepository
    {
        Task<IEnumerable<Decree>> GetDecrees();
        Task<Decree> GetDecreeById(int decreeId);
        Task SaveDecree(Decree decree);
        void DeleteDecree(Decree decree);
    }
}
