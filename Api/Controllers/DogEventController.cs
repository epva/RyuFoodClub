using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RyuFoodClub.Model;
using RyuFoodClub.Model.MongoDB;


namespace RyuFoodClub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogEventController : ControllerBase
    {
        private readonly ILogger<DogEventController> _logger;
        public readonly IDogEventService _dogEventService;

        public DogEventController(IDogEventService dogEventService, ILogger<DogEventController> logger)
        {
            _logger = logger;
            _dogEventService = dogEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogEvent>>> Get()
        {
            var events = await _dogEventService.Get();
            return Ok(events.ToList());
        }
    }
}
