using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class ProcedureTypeConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("Procedures");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.Description)
              .HasMaxLength(50)
              .IsRequired(true);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(16,2)")
                .IsRequired(true);

            builder.HasIndex(x => x.Description)
               .IsUnique();
        }
    }
}
