﻿using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Interfaces;

public interface ICertificateService
{
    Task<Result<CertificateDto>> CreateAsync(CertificateDto dto);
    Task<Result<CertificateDto?>> GetByIdAsync(int id);
    Task<Result<CertificateDto[]>> GetAllAsync(); 
    Task<Result<CertificateDto>> UpdateAsync(int id, CertificateDto dto); 
    Task<Result<bool>> DeleteAsync(int id); 
}