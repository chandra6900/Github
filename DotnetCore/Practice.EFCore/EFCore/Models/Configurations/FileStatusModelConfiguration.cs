using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.Configuration
{
    public partial class FileStatusModelConfiguration : IEntityTypeConfiguration<FileStatusModel>
    {
        public void Configure(EntityTypeBuilder<FileStatusModel> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(40);

            builder.Property(e => e.Status).IsRequired().HasMaxLength(20);

            builder.Property(e => e.Path).HasMaxLength(100);

            builder.Property(e => e.CreationDate).IsRequired().HasColumnType("datetime");

            builder.Property(e => e.UpdationDate).HasColumnType("datetime");

            builder.Property(e => e.Message).HasMaxLength(200);
        }
    }
}
