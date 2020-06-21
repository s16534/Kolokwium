using koloss.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koloss.Services
{
    public interface IDbService
    {
        public GetArtistEventsResponse GetArtist(int artistId);
        UpdatePerformanceDateRequest UpdatePerformanceDate(int artistId, int eventId, DateTime newPerformanceDate);
    }
}
