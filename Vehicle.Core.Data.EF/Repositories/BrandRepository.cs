using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Core.Data.EF.Interfaces;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly DataContext dataContext;

        public BrandRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<bool> ExistBrandWithName(string description)
           => await dataContext.Brands.Where(x => x.Description == description).AnyAsync();

    }
}
