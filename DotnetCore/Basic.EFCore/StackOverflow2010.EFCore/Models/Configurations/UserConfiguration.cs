using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.DisplayName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.EmailHash).HasMaxLength(40);

            builder.Property(e => e.LastAccessDate).HasColumnType("datetime");

            builder.Property(e => e.Location).HasMaxLength(100);

            builder.Property(e => e.WebsiteUrl).HasMaxLength(200);
        }
    }
}
