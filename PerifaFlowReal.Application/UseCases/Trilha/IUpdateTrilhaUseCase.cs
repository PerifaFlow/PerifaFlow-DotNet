using PerifaFlowReal.Application.Dtos.Request;

namespace PerifaFlowReal.Application.UseCases;

public interface IUpdateTrilhaUseCase
{
    Task<bool> Execute(Guid trilhaId, TrilhaRequest request);
}