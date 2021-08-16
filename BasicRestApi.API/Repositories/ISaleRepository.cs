using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSales();
        Task<Sale> GetOneSaleById(int Id);
        Task Delete(int Id);
        Task<Sale> Insert(int Id, int Quantity, int FlowerId, int StoreId);
        Task<Sale> Update(int Id, int Quantity, int FlowerId, int StoreId);
    }
}