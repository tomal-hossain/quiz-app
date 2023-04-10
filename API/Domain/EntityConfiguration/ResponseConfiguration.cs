using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class ResponseConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.ToTable(nameof(Response));
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.QuizId);
            builder.HasIndex(b => b.UserId);
            builder.Property(b => b.UserId).IsRequired().HasColumnType("nvarchar(450)");
            builder.Property(b => b.ResponseTime).IsRequired().HasColumnType("datetime2");

            builder.HasOne(b => b.Quiz)
                .WithMany(q => q.Responses)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.User)
                .WithMany(q => q.Responses)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
