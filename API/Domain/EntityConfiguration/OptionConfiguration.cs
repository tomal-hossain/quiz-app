using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    internal class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable(nameof(Option));
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.QuestionId);
            builder.Property(b => b.Text).IsRequired().HasColumnType("nvarchar(256)");

            builder.HasOne(b => b.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(q => q.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
