using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.Interfaces.Repositories;

public interface IMissaoRepository :  IRepository<Missao>
{
    Task<IEnumerable<Missao>> ListarPorTrilhaAsync(Guid trilhaId);
    
    Task<PaginatedResult<MissaoSummary>> GetPageAsync(
        PageRequest page, 
        MissaoQuery? filter = null, 
        CancellationToken ct = default
    );
}