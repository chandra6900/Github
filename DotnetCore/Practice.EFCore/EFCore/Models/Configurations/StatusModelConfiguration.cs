using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.Configuration
{
    public partial class StatusModelConfiguration : IEntityTypeConfiguration<StatusModel>
    {
        public void Configure(EntityTypeBuilder<StatusModel> builder)
        {
            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Status).HasMaxLength(40);

            builder.Property(e => e.UpdationDate).HasColumnType("datetime");

            builder.Property(e => e.Path).HasMaxLength(100);

            builder.Property(e => e.Message).HasMaxLength(200);
        }
    }
}
