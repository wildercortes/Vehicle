using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vehicle.Core.Data.EF.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int? id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
