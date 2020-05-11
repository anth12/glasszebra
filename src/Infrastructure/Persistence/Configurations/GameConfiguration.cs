using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(55)
                .IsRequired();

            //builder.HasOne(t => t.Owner).WithOne(o=> o.Game);
            //builder.HasMany(t => t.Participants).WithOne(o=> o.Game);
        }
    }
}
