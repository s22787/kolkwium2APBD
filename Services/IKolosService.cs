using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IKolosService
    {

        public Task Delete(int id);
        public Task SaveDatabase();
    }
}
