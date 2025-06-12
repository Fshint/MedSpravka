using System.Text.Json.Serialization;

namespace MedicalCertificate.WebAPI.Contracts;

public class LoginContract
{
    [JsonPropertyName("userName")]
    public string UserName { get; set; } = null!;
        
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}