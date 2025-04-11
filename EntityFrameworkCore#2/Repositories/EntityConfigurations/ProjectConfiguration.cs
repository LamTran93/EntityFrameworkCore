using EntityFrameworkCore_2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore_2.Repositories.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasMany(p => p.ProjectEmployees)
                .WithOne(pe => pe.Project)
                .HasForeignKey(pe => pe.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
