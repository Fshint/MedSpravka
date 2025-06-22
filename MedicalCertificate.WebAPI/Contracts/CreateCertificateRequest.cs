namespace  MedicalCertificate.WebAPI.Contracts;

public class CreateCertificateRequest(
    int UserId, 
    DateTime StartDate, 
    DateTime EndDate, 
    string CertificateType,
    string Clinic,
    string Comment,
    int FilePathId,
    int StatusId,
    string ReviewerComment
    );