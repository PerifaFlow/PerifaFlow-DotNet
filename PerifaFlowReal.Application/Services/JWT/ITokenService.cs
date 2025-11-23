using PerifaFlow.Domain.Entities;

namespace PerifaFlowReal.Application.Interfaces.Services.JWT;

public interface ITokenService
{
    string GenerateToken(User user);
}