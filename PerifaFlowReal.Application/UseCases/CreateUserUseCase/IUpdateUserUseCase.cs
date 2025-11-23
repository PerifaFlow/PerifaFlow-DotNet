using PerifaFlowReal.Application.Dtos.Request;

namespace PerifaFlowReal.Application.UseCases.CreateUserUseCase;

public interface IUpdateUserUseCase
{
    Task<bool> Execute(Guid id, UserRequest request);
}