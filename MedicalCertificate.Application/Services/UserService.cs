using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            _userRepository.Update(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
                _userRepository.Remove(user);
        }
    }
}