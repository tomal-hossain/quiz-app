using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.ToTable(nameof(Quiz));
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Name);
            builder.Property(b => b.AccessIdentifier).IsRequired().HasColumnType("nvarchar(256)");
            builder.Property(b => b.Name).IsRequired().HasColumnType("nvarchar(256)");
            builder.Property(b => b.CreationDate).IsRequired().HasColumnType("datetime2");
        }
    }
}
