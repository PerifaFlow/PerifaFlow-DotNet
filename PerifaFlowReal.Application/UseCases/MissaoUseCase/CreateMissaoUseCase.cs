using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Dtos.Response;
using PerifaFlowReal.Application.Interfaces.Repositories;
using PerifaFlowReal.Application.pagination;

namespace PerifaFlowReal.Application.UseCases.CreateMissaoUseCase;

public class CreateMissaoUseCase(IMissaoRepository missaoRepository) : ICreateMissaoUseCase
{
    public async Task<MissaoResponse> Execute(MissaoRequest request)
    {
        var missao = new Missao(
            request.Titulo,
            request.Descricao,
            request.TrilhaId
        );

        await missaoRepository.AddAsync(missao);

        return new MissaoResponse(
            missao.Id,
            missao.Titulo,
            missao.Descricao,
            missao.TrilhaId
        );
    }

    public Task<PaginatedResult<MissaoSummary>> GetPageAsync(PageRequest page, MissaoQuery? filter = null, CancellationToken ct = default)
    {
        return missaoRepository.GetPageAsync(page, filter, ct);
    }
}