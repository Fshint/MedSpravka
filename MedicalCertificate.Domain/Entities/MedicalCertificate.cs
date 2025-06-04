using MedicalCertificate.Domain.Enums;

namespace MedicalCertificate.Domain.Entities;


public class MedicalCertificate
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string IIN { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Clinic { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public CertificateStatus Status { get; set; } = CertificateStatus.Pending;
    public string? ReviewerComment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
}