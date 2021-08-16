using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task<Store> GetOneStoreById(int id);
        Task Delete(int id);
        Task<Store> Insert(int id, string Name, string Region, string StreetName, int Number);
        Task<Store> Update(int id, string Name, string Region, string StreetName, int Number);
    }
}