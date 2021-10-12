using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class DocumentTypeTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentTypes");

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
