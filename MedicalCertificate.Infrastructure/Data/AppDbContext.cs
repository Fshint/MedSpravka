using MedicalCertificate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalCertificate.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Domain.Entities.MedicalCertificate> Certificates { get; set; } = null!;
}

