using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Database;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ProjectDatabaseContext _context;

        public SaleRepository(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetOneSaleById(int Id)
        {
            return await _context.Sales.FindAsync(Id);
        }

        public async Task Delete(int Id)
        {
            var sale =  await _context.Sales.FindAsync(Id);
            if (sale == null)
            {
                throw new NotFoundException();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<Sale> Insert(int Id, int Quantity, int FlowerId, int StoreId)
        {
            var sale = new Sale
            {
                Id = Id,
                Quantity = Quantity,
                FlowerId = FlowerId,
                StoreId = StoreId
            };
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return await Task.FromResult(sale);
        }

        public async Task<Sale> Update(int Id, int Quantity, int FlowerId, int StoreId)
        {
            var sale = await _context.Sales.FindAsync(Id);
            if (sale == null)
            {
                throw new NotFoundException();
            }

            sale.Quantity = Quantity;
            sale.FlowerId = FlowerId;
            sale.StoreId = StoreId;
            await _context.SaveChangesAsync();
            return await Task.FromResult(sale);
        }
    }
}