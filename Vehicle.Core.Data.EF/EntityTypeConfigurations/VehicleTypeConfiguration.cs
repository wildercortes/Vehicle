using Microsoft.EntityFrameworkCore;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<Entities.Vehicle>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.Model)
               .IsRequired(true);

            builder.Property(x => x.Plaque)
              .IsRequired(true);

            builder.Property(x => x.Line)
               .HasMaxLength(50)
               .IsRequired(true);

            builder.Property(x => x.Color)
               .HasMaxLength(50)
               .IsRequired(true);

            builder.Property(x => x.Remarks)
               .HasMaxLength(100)
               .IsRequired(true);

            builder.HasIndex(x => x.Plaque)
               .IsUnique();

            builder.HasOne(x => x.User)
              .WithMany()
              .HasForeignKey(x => x.UserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehicleType)
            .WithMany()
            .HasForeignKey(x => x.VehicleTypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand)
             .WithMany()
             .HasForeignKey(x => x.BrandId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
