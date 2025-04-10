using EntityFrameworkCore_2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore_2.Repositories.EntityConfigurations
{
    public class SalariesConfiguration : IEntityTypeConfiguration<Salaries>
    {
        public void Configure(EntityTypeBuilder<Salaries> builder)
        {
            builder.ToTable("Salaries");

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
