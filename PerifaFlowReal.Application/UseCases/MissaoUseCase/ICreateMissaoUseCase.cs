using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Dtos.Response;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.UseCases.CreateMissaoUseCase;

public interface ICreateMissaoUseCase
{
    Task<MissaoResponse> Execute(MissaoRequest request);
    
    Task<PaginatedResult<MissaoSummary>> GetPageAsync(
        PageRequest page, 
        MissaoQuery? filter = null, 
        CancellationToken ct = default
    );
}