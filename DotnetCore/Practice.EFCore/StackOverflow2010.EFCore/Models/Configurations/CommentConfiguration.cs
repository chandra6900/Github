using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflow2010.EFCore.Models.Configuration
{
    public partial class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> builder)
        {

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(700);
        }
    }
}
