using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Core.Data.EF.Interfaces;

namespace Vehicle.Core.Data.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext dataContext;

        public GenericRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(T entity)
        {
            dataContext.Set<T>().Add(entity);
            //await db.SaveChangesAsync();
            //return entity;
        }

        public void Delete(int id)
        {
            var entity =  dataContext.Set<T>().Find(id);
            //if (entity == null)
                //return entity;

            dataContext.Set<T>().Remove(entity);
            //await db.SaveChangesAsync();
           // return entity;
        }

        public async Task<T> GetById(int? id)
        {
            return await dataContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await dataContext.Set<T>().ToListAsync();
        }

        public void  Update(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
            //await db.SaveChangesAsync();
            //return entity;
        }

    }
}
