using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RyuFoodClub.Model;


namespace RyuFoodClub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogEventController : ControllerBase
    {
        private readonly ILogger<DogEventController> _logger;

        public DogEventController(ILogger<DogEventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DogEvent> Get()
        {
            var events = new List<DogEvent>();
            events.Add(new DogEvent(DateTime.Now, "1st Event"));
            events.Add(new DogEvent(DateTime.Now.AddHours(-1), "2nd Event"));
            return events;
        }
    }
}
