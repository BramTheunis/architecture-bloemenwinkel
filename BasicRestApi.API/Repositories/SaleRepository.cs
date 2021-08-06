using System.Collections.Generic;
using System.Linq;
using BasicRestAPI.Database;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ProjectDatabaseContext _context;

        public SaleRepository(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _context.Sales.ToList();
        }

        public Sale GetOneSaleById(int Id)
        {
            return _context.Sales.Find(Id);
        }

        public void Delete(int Id)
        {
            var sale = _context.Sales.Find(Id);
            if (sale == null)
            {
                throw new NotFoundException();
            }

            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }

        public Sale Insert(int Id, int Quantity, int FlowerId, int StoreId)
        {
            var sale = new Sale
            {
                Id = Id,
                Quantity = Quantity,
                FlowerId = FlowerId,
                StoreId = StoreId
            };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return sale;
        }

        public Sale Update(int Id, int Quantity, int FlowerId, int StoreId)
        {
            var sale = _context.Sales.Find(Id);
            if (sale == null)
            {
                throw new NotFoundException();
            }

            sale.Quantity = Quantity;
            sale.FlowerId = FlowerId;
            sale.StoreId = StoreId;
            _context.SaveChanges();
            return sale;
        }

    }
}