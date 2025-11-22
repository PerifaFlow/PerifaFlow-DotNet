using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Interfaces.Services;

namespace PerifaFlowReal.Application.UseCases.SugestaoMissaoUseCase;

public class SugerirMissaoUseCase(IRitimoService service)
{
    public async Task<SugestaoMissaoResponse> ExecuteAsync(
        SugestaoMissaoRequest request,
        string? token,
        CancellationToken ct = default)
    {
        return await service.SugerirMissaoAsync(request, token, ct);
    }
}