using System.Linq;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Web;
using BasicRestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasicRestAPI.Controllers
{
    [ApiController]
    [Route("stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger<StoreController> _logger;
        
        public StoreController(IStoreRepository storeRepository, ILogger<StoreController> logger)
        {
            _storeRepository = storeRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllStores()
        {
            _logger.LogInformation("Getting all stores");
            var stores = _storeRepository.GetAllStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public IActionResult StoreById(int id)
        {
            _logger.LogInformation("Getting store by id", id);
            var store = _storeRepository.GetOneStoreById(id);
            return store == null ? (IActionResult) NotFound() : Ok(store);
        }

        [HttpPost]
        public IActionResult CreateStore(StoreUpsertInput input)
        {
            _logger.LogInformation("Creating a store", input);
            var persistedStore = _storeRepository.Insert(input.Id, input.Name, input.Region, input.StreetName, input.Number);
            return Created($"/stores/{persistedStore.Id}", persistedStore);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateStore(int id, StoreUpsertInput input)
        {
            _logger.LogInformation("Updating a store", input);
            try
            {
                var store = _storeRepository.Update(input.Id, input.Name, input.Region, input.StreetName, input.Number);
                return Accepted(store);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            _logger.LogInformation("Deleting a store", id);
            try
            {
                _storeRepository.Delete(id);
               return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}