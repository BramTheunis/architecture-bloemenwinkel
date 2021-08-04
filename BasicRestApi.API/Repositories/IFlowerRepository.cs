using System.Collections.Generic;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public interface IFlowerRepository
    {
        IEnumerable<Flower> GetAllFlowers();
        Flower GetOneFlowerById(int Id);
        void Delete(int Id);
        Flower Insert(int Id, string Name, int Price, string Description);
        Flower Update(int Id, string Name, int Price, string Description);
    }
}