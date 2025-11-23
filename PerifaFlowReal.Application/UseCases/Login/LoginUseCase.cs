using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Dtos.Response;
using PerifaFlowReal.Application.Interfaces.Repositories;
using PerifaFlowReal.Application.Interfaces.Services.JWT;

namespace PerifaFlowReal.Application.UseCases.Login;

public class LoginUseCase(IUserRepository userRepository, ITokenService tokenService) : ILoginUseCase
{
    public async Task<LoginResponse?> Login(LoginRequest request)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        
        if (user is null )
            return await Task.FromResult(new  LoginResponse("Invalid credentials or blocked account"));
        
    
        return await Task.FromResult(new LoginResponse
        {
            Message  = "Login successful",
            Token = tokenService.GenerateToken(user),
            Id = user.Id
        });
    }
}