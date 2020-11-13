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
        private readonly IDogEventService _dogEventService;

        public DogEventController(IDogEventService dogEventService, ILogger<DogEventController> logger)
        {
            _logger = logger;
            _dogEventService = dogEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogEvent>>> Get()
        {
            var dogEvents = await _dogEventService.Get();
            return Ok(dogEvents.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DogEvent>> GetById(string id)
        {
            var dogEvent = await _dogEventService.Get(id);
            return Ok(dogEvent);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DogEvent dogEvent)
        {
            await _dogEventService.Create(dogEvent);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(DogEvent dogEvent)
        {
            await Task.Run(() =>
                _dogEventService.Update(dogEvent.Id, dogEvent)
            );
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DogEvent dogEvent)
        {
            await Task.Run(() => 
                _dogEventService.Delete(dogEvent.Id)
            );
            return NoContent();
        }
    }
}
