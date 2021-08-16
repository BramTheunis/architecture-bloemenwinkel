using System.Collections.Generic;
using System.Threading.Tasks;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Repositories
{
    public interface IFlowerRepository
    {
        Task<IEnumerable<Flower>> GetAllFlowers();
        Task<Flower> GetOneFlowerById(int Id);
        Task Delete(int Id);
        Task<Flower> Insert(int Id, string Name, int Price, string Description);
        Task<Flower> Update(int Id, string Name, int Price, string Description);
    }
}