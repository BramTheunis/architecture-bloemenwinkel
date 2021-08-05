using System.Collections.Generic;
using System.Linq;
using BasicRestAPI.Database;
using BasicRestAPI.Model;
using BasicRestAPI.Model.Domain;
// using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly GarageDatabaseContext _context;

        public FlowerRepository(GarageDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Flower> GetAllFlowers()
        {
            return _context.Flowers.ToList();
        }

        public Flower GetOneFlowerById(int Id)
        {
            return _context.Flowers.Find(Id);
        }


        public void Delete(int Id)
        {
            var flower = _context.Flowers.Find(Id);
            if (flower == null)
            {
                throw new NotFoundException();
            }

            _context.Flowers.Remove(flower);
            _context.SaveChanges();
        }

        public Flower Insert(int Id, string Name, int Price, string Description)
        {
            var flower = new Flower
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Description = Description
            };
            _context.Flowers.Add(flower);
            _context.SaveChanges();
            return flower;

        }

        public Flower Update(int Id, string Name, int Price, string Description)
        {
            var flower = _context.Flowers.Find(Id);
            if (flower == null)
            {
                throw new NotFoundException();
            }

            flower.Name = Name;
            flower.Price = Price;
            flower.Description = Description;
            _context.SaveChanges();
            return flower;
        }
    }
}