using kolos2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IKolosService
    {
        public Task<MusicianDTO> GetMusician(int id);
        public Task<bool> MusExists(int id);

        public Task DeleteMusician(int id);
        public Task SaveDatabase();
    }
}
