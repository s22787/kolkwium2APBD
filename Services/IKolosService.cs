using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IKolosService
    {
        public Task GetMusician(int id);

        public Task DeleteMusician(int id);
        public Task SaveDatabase();
    }
}
