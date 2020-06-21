using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using koloss.Exceptions;
using koloss.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace koloss.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IDbService _service;

        public ArtistController(IDbService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("{artistId}")]
        public IActionResult GetArtist(int artistId)
        {
            IActionResult response;
            try
            {
                response = Ok(_service.GetArtist(artistId));

            }
            catch (NoArtistException e)
            {
                response = NotFound($"{e.Message}");
            }
            return response;
        }


        [HttpPut]
        [Route("{artistId}/events/{eventId}")]
        public IActionResult UpdatePerformanceDate(int artistId, int eventId, DateTime newPerformanceDate)
        {
            IActionResult response;
            try
            {
                response = Ok(_service.UpdatePerformanceDate(artistId));

            }
            catch (NoArtistException e)
            {
                response = NotFound($"{e.Message}");
            }
            catch (NoEventException e)
            {
                response = NotFound($"{e.Message}");
            }
            catch (WrongNewPerformanceDataException e)
            {
                response = NotFound($"{e.Message}");
            }
            return response;
        }
    }
}
