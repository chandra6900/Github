using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class VoteTypeConfiguration : IEntityTypeConfiguration<VoteTypeModel>
    {
        public void Configure(EntityTypeBuilder<VoteTypeModel> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
