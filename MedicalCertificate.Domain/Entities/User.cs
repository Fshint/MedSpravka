using MedicalCertificate.Domain.Enums;
using MedicalCertificate.Domain.Entities;
namespace MedicalCertificate.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string IIN { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Student;

    public List<MedicalCertificate> Certificates { get; set; } = new();
}