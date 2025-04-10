using EntityFrameworkCore_2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore_2.Repositories.EntityConfigurations
{
    public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.ToTable("Project_Employee");

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
