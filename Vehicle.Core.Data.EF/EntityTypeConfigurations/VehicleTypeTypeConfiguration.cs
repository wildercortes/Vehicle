using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class VehicleTypeTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable("VehicleTypes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.Description)
              .HasMaxLength(50)
              .IsRequired(true);

            builder.HasIndex(x => x.Description)
               .IsUnique();
        }
    }
}
