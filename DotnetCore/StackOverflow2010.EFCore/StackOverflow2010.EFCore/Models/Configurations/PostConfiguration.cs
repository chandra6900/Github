using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class PostConfiguration : IEntityTypeConfiguration<PostModel>
    {
        public void Configure(EntityTypeBuilder<PostModel> builder)
        {
            builder.Property(e => e.Body).IsRequired();

            builder.Property(e => e.ClosedDate).HasColumnType("datetime");

            builder.Property(e => e.CommunityOwnedDate).HasColumnType("datetime");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.LastActivityDate).HasColumnType("datetime");

            builder.Property(e => e.LastEditDate).HasColumnType("datetime");

            builder.Property(e => e.LastEditorDisplayName).HasMaxLength(40);

            builder.Property(e => e.Tags).HasMaxLength(150);

            builder.Property(e => e.Title).HasMaxLength(250);
        }
    }
}
