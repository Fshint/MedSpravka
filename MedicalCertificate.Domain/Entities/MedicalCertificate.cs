namespace MedicalCertificate.Domain.Entities
{
    public class MedicalCertificate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Clinic { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public Guid FilePathId { get; set; }
        public int StatusId { get; set; }
        public string ReviewerComment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public File? FilePath { get; set; }
        public CertificateStatus? Status { get; set; }
        public ICollection<CertificateStatusHistory>? StatusHistories { get; set; }
    }
}