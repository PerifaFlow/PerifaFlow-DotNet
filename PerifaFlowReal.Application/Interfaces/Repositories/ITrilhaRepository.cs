using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.Interfaces.Repositories;

public interface ITrilhaRepository : IRepository<Trilha>
{
    Task<PaginatedResult<TrilhaSummary>> GetPageAsync(
        PageRequest page, 
        TrilhaQuery? filter = null, 
        CancellationToken ct = default
    );
}