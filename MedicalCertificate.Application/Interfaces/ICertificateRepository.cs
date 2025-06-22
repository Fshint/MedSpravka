using MedicalCertificate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Interfaces;

    public interface ICertificateRepository : IRepository<Certificate>
    {
        Task<IEnumerable<Certificate>> GetAllWithStatusAsync();
        Task<Certificate?> GetByIdWithStatusAsync(int id);
    }

