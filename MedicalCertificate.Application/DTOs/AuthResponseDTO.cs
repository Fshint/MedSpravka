using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.DTOs 
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int UserId { get; set; }
    }
}