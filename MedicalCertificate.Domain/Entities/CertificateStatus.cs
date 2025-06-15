namespace MedicalCertificate.Domain.Entities
{
    public class CertificateStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<MedicalCertificate>? MedicalCertificates { get; set; }
        public ICollection<CertificateStatusHistory>? StatusHistories { get; set; }
    }
}