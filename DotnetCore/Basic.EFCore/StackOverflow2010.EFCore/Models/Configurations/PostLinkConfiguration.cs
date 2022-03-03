using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class PostLinkConfiguration : IEntityTypeConfiguration<PostLinkModel>
    {
        public void Configure(EntityTypeBuilder<PostLinkModel> builder)
        {
            builder.Property(e => e.CreationDate).HasColumnType("datetime");
        }
    }
}
