using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Interfaces.Repositories;

namespace PerifaFlowReal.Application.UseCases.PortFolio;

public class UpdatePortfolio(IPortfolioRepository  portfolioRepository): IUpdatePortfolioUseCase
{
    public async Task<bool> Execute(Guid portfolioId, PortfolioRequest request)
    {
        var portfolio = await portfolioRepository.GetByIdAsync(portfolioId);
        if(portfolio == null)
            throw  new KeyNotFoundException("MISSAO not found");

        portfolio.Update(request.Titulo, request.Url);
        
        await portfolioRepository.UpdateAsync(portfolio);
        return true;
    }
}