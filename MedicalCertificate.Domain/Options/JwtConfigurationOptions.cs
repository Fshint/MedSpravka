namespace MedicalCertificate.Domain.Options;

public class JwtConfigurationOptions
{
    public const string SectionName = nameof(JwtConfigurationOptions);
    public string Key { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpirationHours { get; set; }
}