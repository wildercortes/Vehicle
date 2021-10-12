using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class DetailTypeConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable("Details");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.LaborPrice)
                   .IsRequired(true);

            builder.Property(x => x.SparePartsPrice)
                  .IsRequired(true);

            builder.Property(x => x.Remarks)
                  .IsRequired(true);

            builder.HasOne(x => x.Procedure)
              .WithMany()
              .HasForeignKey(x => x.ProcedureId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.History)
               .WithMany()
               .HasForeignKey(x => x.HistoryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
