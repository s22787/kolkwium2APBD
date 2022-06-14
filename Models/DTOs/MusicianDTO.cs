using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models.DTOs
{
    public class MusicianDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public IEnumerable<TrackDTO> Tracks { get; set; }
    }

    public class TrackDTO 
    {
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }

}
