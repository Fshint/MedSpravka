namespace MedicalCertificate.Domain.Entities
{
    public class CertificateStatus
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public ICollection<Certificate>? Certificates { get; set; }
        public ICollection<CertificateStatusHistory>? StatusHistories { get; set; }
    }
}