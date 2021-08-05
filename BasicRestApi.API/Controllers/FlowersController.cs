using System.Linq;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Web;
using BasicRestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasicRestAPI.Controllers
{
    [ApiController]
    [Route("flowers")]
    public class FlowerController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IFlowerRepository _flowerRepository;

        // notice that we pass in the repository instead of the database directly, this means you "abstract away" any database details.
        // this is useful when you want to replace your relational database with a document db for example.
        public FlowerController(IFlowerRepository flowerRepository, ILogger<StoreController> logger)
        {
            _logger = logger;
            _flowerRepository = flowerRepository;
        }


        [HttpGet]
        public IActionResult GetAllFlowers()
        {
            _logger.LogInformation($"Getting all flowers");
            try
            {
                return Ok(_flowerRepository.GetAllFlowers());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetOneFlower(int Id)
        {
            _logger.LogInformation("Getting flower by id", Id);
            var flower = _flowerRepository.GetOneFlowerById(Id);
            return flower == null ? (IActionResult) NotFound() : Ok(flower);
        }

        [HttpPost]
        public IActionResult CreateFlower(int storeId, FlowerUpsertInput input)
        {
            _logger.LogInformation($"Creating a flower");
            try
            {
                var persistedFlower = _flowerRepository.Insert(input.Id, input.Name, input.Price, input.Description);
                return Created($"/flowers/{persistedFlower.Id}", persistedFlower);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("{flowers/{Id}}")]
        public IActionResult UpdateFlowerInStore(int Id, FlowerUpsertInput input)
        {
            _logger.LogInformation($"Updating flower {Id}");
            try
            {
                _flowerRepository.Update(input.Id, input.Name, input.Price, input.Description);
                return Accepted();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{flowers/{Id}")]
        public IActionResult DeleteFlowerFromStore(int Id)
        {
            _logger.LogInformation($"Deleting flower {Id}");
            try
            {
                _flowerRepository.Delete(Id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}