using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Interfaces.Services;

namespace PerifaFlowReal.Application.UseCases.Java.RegistrarRitimoUseCase;

public class RegistrarRitimoUseCase(IRitimoService service)
{
    public async Task ExecuteAsync(
        RitmoRegistroDto request,
        string? token,
        CancellationToken ct = default)
    {
        await service.RegistrarAsync(request, token, ct);
    }
}