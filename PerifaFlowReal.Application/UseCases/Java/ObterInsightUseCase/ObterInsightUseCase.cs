using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Interfaces.Services;

namespace PerifaFlowReal.Application.UseCases.ObterInsightUseCase;

public class ObterInsightUseCase(IRitimoService service)
{
    public async Task<IEnumerable<InsightDto>> ExecuteAsync(
        string bairro,
        DateTime de,
        DateTime ate,
        string? token,
        CancellationToken ct = default)
    {
        return await service.ObterInsightsAsync(bairro, de, ate, token, ct);
    }
}