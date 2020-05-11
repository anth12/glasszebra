using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(t => t.Text)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Hint)
	            .HasMaxLength(255)
	            .IsRequired();
        }
    }
}
