using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllFlowers()
        {
            _logger.LogInformation($"Getting all flowers");
            try
            {
                return Ok(await _flowerRepository.GetAllFlowers());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOneFlower(int Id)
        {
            _logger.LogInformation("Getting flower by id", Id);
            var flower = await _flowerRepository.GetOneFlowerById(Id);
            return flower == null ? (IActionResult) NotFound() : Ok(flower);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlower(int storeId, FlowerUpsertInput input)
        {
            _logger.LogInformation($"Creating a flower");
            try
            {
                var persistedFlower = await _flowerRepository.Insert(input.Id, input.Name, input.Price, input.Description);
                return Created($"/flowers/{persistedFlower.Id}", persistedFlower);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateFlowerInStore(int Id, FlowerUpsertInput input)
        {
            _logger.LogInformation($"Updating flower {Id}");
            try
            {
                await _flowerRepository.Update(input.Id, input.Name, input.Price, input.Description);
                return Accepted();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFlowerFromStore(int Id)
        {
            _logger.LogInformation($"Deleting flower {Id}");
            try
            {
                await _flowerRepository.Delete(Id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}