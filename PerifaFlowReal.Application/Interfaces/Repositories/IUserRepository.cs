using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.Interfaces.Repositories;

public interface IUserRepository:IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<PaginatedResult<UserSummary>> GetPageAsync(
        PageRequest page, 
        UserQuery? filter = null, 
        CancellationToken ct = default
    );
}