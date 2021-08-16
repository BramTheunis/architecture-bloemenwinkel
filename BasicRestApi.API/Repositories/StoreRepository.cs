using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Database;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ProjectDatabaseContext _context;

        public StoreRepository(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllStores()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetOneStoreById(int Id)
        {
            return await _context.Stores.FindAsync(Id);
        }

        public async Task Delete(int Id)
        {
            var store = await _context.Stores.FindAsync(Id);
            if (store == null)
            {
                throw new NotFoundException();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task<Store> Insert(int Id, string Name, string Region, string StreetName, int Number)
        {
            var store = new Store
            {
                Id = Id,
                Name = Name,
                Region = Region,
                StreetName = StreetName,
                Number = Number
            };
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return await Task.FromResult(store);
        }

        public async Task<Store> Update(int Id, string Name, string Region, string StreetName, int Number)
        {
            var store = await _context.Stores.FindAsync(Id);
            if (store == null)
            {
                throw new NotFoundException();
            }

            store.Name = Name;
            store.Region = Region;
            store.StreetName = StreetName;
            store.Number = Number;
            await _context.SaveChangesAsync();
            return await Task.FromResult(store);
        }

    }
}