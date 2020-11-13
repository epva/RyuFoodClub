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
        protected IDogService _dogService;
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
    }   
}   
