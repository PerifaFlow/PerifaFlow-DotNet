using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Dtos.Response;

namespace PerifaFlowReal.Application.UseCases.PortFolio;

public interface ICreatePortfolioUseCase
{
    Task<PortfolioResponse>  CreatePortfolio(PortfolioRequest request);
}