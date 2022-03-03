using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class LinkTypeConfiguration : IEntityTypeConfiguration<LinkTypeModel>
    {
        public void Configure(EntityTypeBuilder<LinkTypeModel> builder)
        {
            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
