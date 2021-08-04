using System.Linq;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Web;
// using BasicRestAPI.Repositories;
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


        [HttpGet("{storeId}/flowers")]
        public IActionResult GetAllFlowersForStore(int storeId)
        {
            _logger.LogInformation($"Getting all flowers for store {storeId}");
            try
            {
                return Ok(_flowerRepository.GetAllFlowers(storeId).Select(x => x.Convert()).ToList());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{storeId}/flowers")]
        public IActionResult AddFlowerToStore(int storeId, FlowerUpsertInput input)
        {
            _logger.LogInformation($"Creating a flower for store {storeId}");
            try
            {
                var persistedFlower = _flowerRepository.Insert(flowerId, input.Name, input.Price, input.Description);
                return Created($"/stores/{storeId}/flowers/{persistedFlower.Id}", persistedFlower.Convert());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}/flowers/{flowerId}")]
        public IActionResult UpdateFlowerInStore(int storeId, int flowerId, FlowerUpsertInput input)
        {
            _logger.LogInformation($"Updating flower {flowerId} for store {storeId}");
            try
            {
                _flowerRepository.Update(storeId, flowerId, input.Name, input.Price, input.Description);
                return Accepted();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}/flowers/{flowerId}")]
        public IActionResult DeleteFlowerFromStore(int storeId, int flowerId)
        {
            _logger.LogInformation($"Deleting flower {flowerId} from store {storeId}");
            try
            {
                _flowerRepository.Delete(storeId, flowerId);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}