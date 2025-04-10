using EntityFrameworkCore_2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore_2.Repositories.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(d => d.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");

            builder.HasData(
                    new Department { Id = 1, Name = "Software Development" },
                    new Department { Id = 2, Name = "Finance" },
                    new Department { Id = 3, Name = "Accountant" },
                    new Department { Id = 4, Name = "HR" }
                );
        }

    }
}
