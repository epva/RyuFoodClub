using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using RyuFoodClub.Model;
using RyuFoodClub.Model.MongoDB;


namespace RyuFoodClub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly ILogger<DogController> _logger;
        private IDogService _dogService;
        public DogController(IDogService dogService, ILogger<DogController> logger)
        {
            _logger = logger;
            _dogService = dogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetAll()
        {
            var dogs = await _dogService.Get();
            return Ok(dogs.ToList());
        }

        [HttpGet]
        public async Task<ActionResult<Dog>> GetById(string id)
        {
            var dog = await _dogService.Get(id);
            return Ok(dog);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Dog dog)
        {
            await _dogService.Create(dog);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Dog dog)
        {
            await Task.Run(() =>
                _dogService.Update(dog.Id, dog)
            );
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Dog dog)
        {
            await Task.Run(() =>
                _dogService.Delete(dog.Id)
            );
            return NoContent();
        }
    }   
}   
