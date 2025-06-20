using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MedicalCertificate.Domain.Entities;

namespace MedicalCertificate.Application.CQRS.Commands; 

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
{
    private readonly IAuthService _authService; 
    private readonly IUserService _userService;
    public LoginCommandHandler(IAuthService authService, IUserService userService, IRepository<User> userRepository)
    {
        _authService = authService;
        _userService = userService;
    }

    public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken) 
    { 
        var loginDto = new LoginDTO 
        { 
            Email = request.email,
          
            Password = request.Password
        };

        var result = await _authService.LoginAsync(loginDto);
        if (result.IsFailed) 
            return result;
            
        if (result.Value.RoleId > 0)
        {
            var roleResult = await _userService.GetByIdAsync(result.Value.RoleId);
            if (roleResult.IsFailed)
                return Result.Failure<AuthResponseDto>(roleResult.Error);
        }
        return result; 
    }
}