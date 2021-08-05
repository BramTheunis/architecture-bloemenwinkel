using System.Collections.Generic;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAllStores();
        Store GetOneStoreById(int id);
        void Delete(int id);
        Store Insert(int id, string Name, string Region, string StreetName, int Number);
        Store Update(int id, string Name, string Region, string StreetName, int Number);
    }
}