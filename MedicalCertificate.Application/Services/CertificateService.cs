using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Constants;
using MedicalCertificate.Domain.Entities;
using KDS.Primitives.FluentResult;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        public CertificateService(ICertificateRepository certificateRepository)
        {
            _Certificaterepository = CertificateRepository;
        }

        public async Task<Result<CertificateDto>> CreateAsync(CertificateDto dto)
        {
            var certificate = new Certificate
            {
                Title = dto.Title,
                Description = dto.Description,
                WorkType = dto.WorkType,
                IsStudentSuggested = dto.IsStudentSuggested,
                CreatedByUserId = dto.CreatedByUserId,
                SupervisorId = dto.SupervisorId,
                StatusId = dto.StatusId,
                IsApprovedByDepartment = dto.IsApprovedByDepartment
            };

            await _unitOfWork.Certificate.AddAsync(certificate);
            await _unitOfWork.SaveChangesAsync();

            var created = await _unitOfWork.Certificate.GetByIdAsync(certificate.Id);
            if (created == null)
                return Result.Failure<CertificateDto>(new Error(ErrorCode.NotFound, "Ошибка при получении созданной темы."));

            dto.Id = created.Id;
            return dto;
        }

        public async Task<Result<CertificateDto?>> GetByIdAsync(int id)
        {
            var certificate = await _unitOfWork.Certificate.GetByIdAsync(id);

            if (certificate == null)
                return Result.Failure<CertificateDto?>(new Error(ErrorCode.NotFound, $"Тема с ID {id} не найдена."));

            var dto = new CertificateDto
            {
                Id = certificate.Id,
                Title = certificate.Title,
                Description = certificate.Description,
                WorkType = certificate.WorkType,
                IsStudentSuggested = certificate.IsStudentSuggested,
                CreatedByUserId = certificate.CreatedByUserId,
                SupervisorId = certificate.SupervisorId,
                StatusId = certificate.StatusId,
                IsApprovedByDepartment = certificate.IsApprovedByDepartment
            };

            return dto;
        }

        public async Task<Result<CerficateDTO[]>> GetAllAsync()
        {
            var certificate = await _unitOfWork.Certificates.GetAllAsync();

            if (!certificates.Any())
                return Result.Failure<CertificateDto[]>(new Error(ErrorCode.NotFound, "Сертификатов нет."));

            var result = certificates.Select(certificate => new CertificateDto
            {
                Id = certificate.Id,
                Title = certificate.Title,
                Description = certificate.Description,
                WorkType = certificate.WorkType,
                IsStudentSuggested = certificate.IsStudentSuggested,
                CreatedByUserId = certificate.CreatedByUserId,
                SupervisorId = certificate.SupervisorId,
                StatusId = certificate.StatusId,
                IsApprovedByDepartment = certificate.IsApprovedByDepartment
            }).ToArray();

            return result;
        }

        public async Task<Result<CertificateDto>> UpdateAsync(int id, CertificateDto dto)
        {
            var certificate = await _unitOfWork.Certificates.GetByIdAsync(id);

            if (certificate == null)
                return Result.Failure<CertificateDto>(new Error(ErrorCode.NotFound, $"Тема с ID {id} не найдена."));

            certificate.Title = dto.Title;
            certificate.Description = dto.Description;
            certificate.WorkType = dto.WorkType;
            certificate.IsStudentSuggested = dto.IsStudentSuggested;
            certificate.SupervisorId = dto.SupervisorId;
            certificate.StatusId = dto.StatusId;
            certificate.IsApprovedByDepartment = dto.IsApprovedByDepartment;

            await _unitOfWork.Certificate.UpdateAsync(certificate);
            await _unitOfWork.SaveChangesAsync();

            var updated = await _unitOfWork.Certificates.GetByIdAsync(id);
            if (updated == null)
                return Result.Failure<CertificateDto>(new Error(ErrorCode.NotFound, "Ошибка при получении обновлённой темы."));

            dto.Id = updated.Id;
            return dto;
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var certificate = await _unitOfWork.Certificates.GetByIdAsync(id);

            if (certificate == null)
                return Result.Failure<bool>(new Error(ErrorCode.NotFound, $"Тема с ID {id} не найдена."));

            await _unitOfWork.Certificates.RemoveAsync(certificate);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}