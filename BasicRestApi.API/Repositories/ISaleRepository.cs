using System.Collections.Generic;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllSales();
        Sale GetOneSaleById(int Id);
        void Delete(int Id);
        Sale Insert(int Id, int Quantity, int FlowerId, int StoreId);
        Sale Update(int Id, int Quantity, int FlowerId, int StoreId);
    }
}