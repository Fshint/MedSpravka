using MedicalCertificate.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace MedicalCertificate.Infrastructure.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateStatusHistory> CertificateStatusHistories { get; set; }
        public DbSet<CertificateStatus> CertificateStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasQueryFilter(e => !e.IsDeleted)
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Office Registrar" },
                new Role { Id = 2, Name = "Student" });
            
            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.FilePath)
                .WithMany()
                .HasForeignKey(c => c.FilePathId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.Status)
                .WithMany()
                .HasForeignKey(c => c.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.StatusHistories)
                .WithMany()
                .HasForeignKey(h => h.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}