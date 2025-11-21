using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.Interfaces.Repositories;

public interface IEntregaRepository
{
    Task<PaginatedResult<EntregaSummary>> GetPageAsync(
        PageRequest page, 
        EntregaQuery? filter = null, 
        CancellationToken ct = default
    );
}