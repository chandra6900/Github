using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class VoteConfiguration : IEntityTypeConfiguration<VoteModel>
    {
        public void Configure(EntityTypeBuilder<VoteModel> builder)
        {
            builder.Property(e => e.CreationDate).HasColumnType("datetime");
        }
    }
}
