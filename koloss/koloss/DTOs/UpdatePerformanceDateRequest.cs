using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace koloss.DTOs
{ 
    public class UpdatePerformanceDateRequest
    {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime newPerformanceDate { get; set; }
    }
}
