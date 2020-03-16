using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFiredRepository
    {
        IEnumerable<Fired> GetFireds();
        Task<Fired> GetFiredById(int firedId);
        Task SaveFired(Fired Fired);
        void DeleteFired(Fired Fired);
    }
}
