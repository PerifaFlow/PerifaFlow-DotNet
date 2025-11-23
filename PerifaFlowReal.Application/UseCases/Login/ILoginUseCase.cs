using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Dtos.Response;

namespace PerifaFlowReal.Application.UseCases.Login;

public interface  ILoginUseCase
{
    Task<LoginResponse?> Login(LoginRequest request);
}