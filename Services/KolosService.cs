using kolos2.Models;
using kolos2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public class KolosService : IKolosService
    {
        private readonly KolosDbContext _context;

        public KolosService(KolosDbContext context) 
        {
            _context = context;
        }

        public async Task<MusicianDTO> GetMusician(int id) 
        {
            var mus = _context.Musician.Where(e => e.IdMusician == id).FirstOrDefault();
            //if(mus)

            return await _context.Musician.Where(e => e.IdMusician == id)
                .Select(e => new MusicianDTO
                {
                    FirstName=e.FirstName,
                    LastName=e.LastName,
                    Nickname=e.Nickname,
                   
                }).FirstAsync();
            

            
        }

        public async Task DeleteMusician(int id) 
        {
            /*var Musician = _context.Album.Where(e => e.IdAlbum == id).FirstOrDefault();
            _context.Remove(Musician);*/
            await _context.SaveChangesAsync();
        }

        public async Task SaveDatabase()
        {
            await _context.SaveChangesAsync();
        }
    }
}
