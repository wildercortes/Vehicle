using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Brand> Brands { get; set; }

        //public DbSet<Detail> Details { get; set; }

        //public DbSet<DocumentType> DocumentTypes { get; set; }

        //public DbSet<History> Histories { get; set; }

        //public DbSet<Procedure> Procedures { get; set; }

        //public DbSet<Entities.Vehicle> Vehicles { get; set; }

        //public DbSet<VehiclePhoto> VehiclePhotos { get; set; }

        //public DbSet<VehicleType> VehicleTypes { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntities(modelBuilder);
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            var entityTypeConfigurationTypes = GetType().Assembly.GetTypes()
                            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                            .ToList();

            var genericMethodDefinition = GetType()
                .GetMethod(nameof(ApplyEntityTypeConfiguration), BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var entityTypeConfigurationType in entityTypeConfigurationTypes)
            {
                var genericMethod = genericMethodDefinition
                    .MakeGenericMethod(new[] {
                        entityTypeConfigurationType,
                        entityTypeConfigurationType.GetInterfaces()[0].GetGenericArguments()[0]
                    });

                genericMethod.Invoke(this, new[] { modelBuilder });
            }
        }

        private void ApplyEntityTypeConfiguration<TEntityTypeConfiguration, TEntity>(ModelBuilder modelBuilder)
            where TEntity : class
            where TEntityTypeConfiguration : IEntityTypeConfiguration<TEntity>, new()
        {
            modelBuilder.ApplyConfiguration(new TEntityTypeConfiguration());
        }
    }
}
