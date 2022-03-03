using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StackOverflow2010.EFCore.Models.Configuration
{
    public class BadgeConfiguration:IEntityTypeConfiguration<BadgeModel>
    {
        public void Configure(EntityTypeBuilder<BadgeModel> builder)
        {

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
        }
    }
}
