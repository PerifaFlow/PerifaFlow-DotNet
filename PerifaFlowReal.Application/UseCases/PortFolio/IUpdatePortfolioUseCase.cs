using PerifaFlowReal.Application.Dtos.Request;

namespace PerifaFlowReal.Application.UseCases.PortFolio;

public interface IUpdatePortfolioUseCase
{
    Task<bool> Execute(Guid portfolioId, PortfolioRequest request);
}