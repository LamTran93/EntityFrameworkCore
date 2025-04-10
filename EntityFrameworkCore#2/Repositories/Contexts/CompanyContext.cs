using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Contexts
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salaries>(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<Employee>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(d => d.Id)
                .IsRequired();
            modelBuilder.Entity<Department>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Department>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity(typeof(ProjectEmployee));
            modelBuilder.Entity<Project>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Project>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Salaries>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Salaries>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<ProjectEmployee>()
                .ToTable("Project_Employee");
            modelBuilder.Entity<ProjectEmployee>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<ProjectEmployee>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Department>(
                d => d.HasData(
                    new Department { Id = 1, Name = "Software Development" },
                    new Department { Id = 2, Name = "Finance" },
                    new Department { Id = 3, Name = "Accountant" },
                    new Department { Id = 4, Name = "HR" }
                    )
                );
        }

        
    }
}
