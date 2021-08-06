using BasicRestAPI.Model;
using BasicRestAPI.Model.Web;
using BasicRestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasicRestAPI.Controllers
{
    [ApiController]
    [Route("sales")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<SaleController> _logger;
        
        public SaleController(ISaleRepository saleRepository, ILogger<SaleController> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            _logger.LogInformation("Getting all sales");
            var sales = _saleRepository.GetAllSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult SaleById(int id)
        {
            _logger.LogInformation("Getting sale by id", id);
            var sale = _saleRepository.GetOneSaleById(id);
            return sale == null ? (IActionResult) NotFound() : Ok(sale);
        }

        [HttpPost]
        public IActionResult CreateSale(SaleUpsertInput input)
        {
            _logger.LogInformation("Creating a sale", input);
            var persistedSale = _saleRepository.Insert(input.Id, input.Quantity, input.FlowerId, input.StoreId);
            return Created($"/sales/{persistedSale.Id}", persistedSale);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateSale(int id, SaleUpsertInput input)
        {
            _logger.LogInformation("Updating a sale", input);
            try
            {
                var sale = _saleRepository.Update(input.Id, input.Quantity, input.FlowerId, input.StoreId);
                return Accepted(sale);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            _logger.LogInformation("Deleting a sale", id);
            try
            {
                _saleRepository.Delete(id);
               return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}