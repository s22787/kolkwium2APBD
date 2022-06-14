using kolos2.Models;
using kolos2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

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

        public async Task<bool> MusExists(int id) 
        {
            return _context.Musician.Where(e => e.IdMusician == id).Any();
        }

        public async Task DeleteMusician(int id) 
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var tracks= _context.MusicianTrack.Where(e => e.IdMusician == id).ToList();
                foreach (var t in tracks)
                {
                    var TrackMus = _context.MusicianTrack.Where(e => e.IdMusician == t.IdMusician);
                    _context.Remove(TrackMus);
                    //await _context.SaveChangesAsync();
                }
                var mus = _context.Album.Where(e => e.IdAlbum == id).FirstOrDefault();
                _context.Remove(mus);
                //await _context.SaveChangesAsync();
                transaction.Complete();
            }
            await _context.SaveChangesAsync();
        }

        public async Task SaveDatabase()
        {
            await _context.SaveChangesAsync();
        }
    }
}
