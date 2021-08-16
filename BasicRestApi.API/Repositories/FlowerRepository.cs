using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Database;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly ProjectDatabaseContext _context;

        public FlowerRepository(ProjectDatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Flower>> GetAllFlowers()
        {
            return await _context.Flowers.ToListAsync();
            
        }

        public async Task<Flower> GetOneFlowerById(int Id)
        {
            return await _context.Flowers.FindAsync(Id);
        }


        public async Task Delete(int Id)
        {
            var flower = _context.Flowers.Find(Id);
            if (flower == null)
            {
                throw new NotFoundException();
            }

            _context.Flowers.Remove(flower);
            await _context.SaveChangesAsync();
        }

        public async Task<Flower> Insert(int Id, string Name, int Price, string Description)
        {
            var flower = new Flower
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Description = Description
            };
            _context.Flowers.Add(flower);
            await _context.SaveChangesAsync();
            return await Task.FromResult(flower);

        }

        public async Task<Flower> Update(int Id, string Name, int Price, string Description)
        {
            var flower = _context.Flowers.Find(Id);
            if (flower == null)
            {
                throw new NotFoundException();
            }

            flower.Name = Name;
            flower.Price = Price;
            flower.Description = Description;
            await _context.SaveChangesAsync();
            return await Task.FromResult(flower);
        }
    }
}