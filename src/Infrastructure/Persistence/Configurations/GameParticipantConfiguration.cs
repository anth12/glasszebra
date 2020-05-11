using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class GameParticipantConfiguration : IEntityTypeConfiguration<GameParticipant>
    {
        public void Configure(EntityTypeBuilder<GameParticipant> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder.Property(t => t.Image)
	            .HasMaxLength(255) // TODO
	            .IsRequired();
        }
    }
}
