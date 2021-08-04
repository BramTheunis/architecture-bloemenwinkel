using System.Collections.Generic;
using System.Linq;
using BasicRestAPI.Database;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDatabaseContext _context;

        public StoreRepository(StoreDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }

        public Store GetOneStoreById(int Id)
        {
            return _context.Stores.Find(Id);
        }

        public void Delete(int Id)
        {
            var store = _context.Stores.Find(Id);
            if (store == null)
            {
                throw new NotFoundException();
            }

            _context.Stores.Remove(store);
            _context.SaveChanges();
        }

        public Store Insert(int Id, string Name, string Region)
        {
            var store = new Store
            {
                Id = Id,
                Name = Name,
                Region = Region
            };
            _context.Stores.Add(store);
            _context.SaveChanges();
            return store;
        }

        public Store Update(int Id, string Name, string Region)
        {
            var store = _context.Stores.Find(Id);
            if (store == null)
            {
                throw new NotFoundException();
            }

            store.Name = name;
            store.Region = region;
            _context.SaveChanges();
            return store;
        }

    }
}