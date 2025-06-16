namespace MedicalCertificate.Domain.Entities
{
    public class File
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;

        public ICollection<Certificate>? Certificates { get; set; }
    }
}