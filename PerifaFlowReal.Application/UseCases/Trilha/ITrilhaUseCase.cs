using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Dtos.Response;

namespace PerifaFlowReal.Application.UseCases;

public interface ITrilhaUseCase
{
    Task<TrilhaResponse> CriarAsync(TrilhaRequest request);
}