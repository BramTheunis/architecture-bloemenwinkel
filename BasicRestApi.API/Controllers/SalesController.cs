using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllSales()
        {
            _logger.LogInformation("Getting all sales");
            var sales = await _saleRepository.GetAllSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SaleById(int id)
        {
            _logger.LogInformation("Getting sale by id", id);
            var sale = await _saleRepository.GetOneSaleById(id);
            return sale == null ? (IActionResult) NotFound() : Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleUpsertInput input)
        {
            _logger.LogInformation("Creating a sale", input);
            var persistedSale = await _saleRepository.Insert(input.Id, input.Quantity, input.FlowerId, input.StoreId);
            return Created($"/sales/{persistedSale.Id}", persistedSale);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSale(int id, SaleUpsertInput input)
        {
            _logger.LogInformation("Updating a sale", input);
            try
            {
                var sale = await _saleRepository.Update(input.Id, input.Quantity, input.FlowerId, input.StoreId);
                return Accepted(sale);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            _logger.LogInformation("Deleting a sale", id);
            try
            {
                await _saleRepository.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}