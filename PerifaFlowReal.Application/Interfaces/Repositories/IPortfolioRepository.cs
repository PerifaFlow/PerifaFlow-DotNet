using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.Interfaces.Repositories;

public interface IPortfolioRepository : IRepository<Portfolio>
{
    Task<IEnumerable<Portfolio>> ObterPorUsuarioAsync(Guid usuarioId);
    
    Task<PaginatedResult<PortfolioSummary>> GetPageAsync(
        PageRequest page, 
        PortfolioQuery? filter = null, 
        CancellationToken ct = default
    );
}