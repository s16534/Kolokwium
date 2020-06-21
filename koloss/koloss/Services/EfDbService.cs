
using koloss.DTOs;
using koloss.Exceptions;
using koloss.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koloss.Services
{
    public class EfDbService : IDbService
    {
        private readonly s16534Context _context;

        public EfDbService(s16534Context context)
        {
            _context = context;
        }

        public GetArtistEventsResponse GetArtist(int artistId)
        {
            var artistExist = _context.Artist.Any(a => a.IdArtist.Equals(artistId));
            if (!artistExist)
            {
                throw new NoArtistException("Brak artysty w baziez danych");
            }
            var artist = _context.Artist.Single(e => e.IdArtist.Equals(artistId));

            var artistEvent = _context.ArtistEvent.Where(e => e.IdArtist.Equals(artistId)).ToList();

            List<Event> eventResults = new List<Event>();

            foreach (var eventItem in artistEvent)
            {
                eventResults.Add(
                    _context.Event.Single(x => x.IdEvent.Equals(eventItem.IdEvent))
                );
            }
            List<Event> eventList = new List<Event>(eventResults.OrderByDescending(e => e.StartDate));

            GetArtistEventsResponse artistResponse = new GetArtistEventsResponse
            {
                IdArtist = artist.IdArtist,
                Events = eventList
            };
            return artistResponse;
        }

        public UpdatePerformanceDateRequest UpdatePerformanceDate(int artistId, int eventId, DateTime newPerformanceDate)
        {
            var artistExist = _context.Artist.Any(a => a.IdArtist.Equals(artistId));
            if (!artistExist)
            {
                throw new NoArtistException("Brak artysty w baziez danych");
            }

            var eventExist = _context.Event.Any(e => e.IdEvent.Equals(eventId));
            if(!eventExist)
            {
                throw new NoEventException("Brak wydarzenia w bazie danych");
            }

            var artistEventsByArtists = _context.ArtistEvent.Where(a => a.IdArtist.Equals(artistId)).ToList();
            var artistEventsByEvent = artistEventsByArtists.Where(e => e.IdEvent.Equals(eventId)).Single();
            
            if (artistEventsByEvent.PerformanceDate < newPerformanceDate)
            {
                throw new WrongNewPerformanceDataException("Brak możliwości zmiany. Wskazane wydarzenie juz sie rozpoczelo ");
            }
            
            return null;
        }
    }
}
