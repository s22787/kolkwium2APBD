using kolos2.Models;
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

        public async Task Delete(int id) 
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
