using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class PostTypeConfiguration : IEntityTypeConfiguration<PostTypeModel>
    {
        public void Configure(EntityTypeBuilder<PostTypeModel> builder)
        {
            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
