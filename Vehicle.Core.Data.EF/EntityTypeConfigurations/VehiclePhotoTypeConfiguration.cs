using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class VehiclePhotoTypeConfiguration : IEntityTypeConfiguration<VehiclePhoto>
    {
        public void Configure(EntityTypeBuilder<VehiclePhoto> builder)
        {
            builder.ToTable("VehiclePhotos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.ImageId);

            builder.HasOne(x => x.Vehicle)
              .WithMany()
              .HasForeignKey(x => x.VehicleId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
