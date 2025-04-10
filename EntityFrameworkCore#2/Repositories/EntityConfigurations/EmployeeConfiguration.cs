using EntityFrameworkCore_2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EntityFrameworkCore_2.Repositories.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salaries>(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.ProjectEmployees)
                .WithOne(pe => pe.Employee)
                .HasForeignKey(pe => pe.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
