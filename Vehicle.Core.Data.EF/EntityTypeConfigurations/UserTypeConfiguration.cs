using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Entities;

namespace Vehicle.Core.Data.EF.EntityTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.HasOne(x => x.DocumentType)
               .WithMany()
               .HasForeignKey(x => x.DocumentTypeId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
