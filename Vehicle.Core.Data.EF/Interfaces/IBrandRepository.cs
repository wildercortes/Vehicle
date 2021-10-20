using System.Threading.Tasks;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> ExistBrandWithName(string description);
    }
}
