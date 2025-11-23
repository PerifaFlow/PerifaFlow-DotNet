using PerifaFlowReal.Application.Dtos.Request;

namespace PerifaFlowReal.Application.UseCases.CreateMissaoUseCase;

public interface IUpdateMissaoUseCase
{
    Task<bool> Execute(Guid motoId, MissaoRequest request);
}