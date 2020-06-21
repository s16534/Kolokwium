using koloss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koloss.DTOs
{
    public class GetArtistEventsResponse
    {
        public int IdArtist { get; set; }
        public List<Event> Events { get; set; }
    }
}
