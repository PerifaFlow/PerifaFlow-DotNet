using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Interfaces.Repositories;

namespace PerifaFlowReal.Application.UseCases.CreateMissaoUseCase;

public class UpdateMissaoUseCase(IMissaoRepository  missaoRepository):IUpdateMissaoUseCase
{
    public async Task<bool> Execute(Guid missaoId, MissaoRequest request)
    {
        var missao = await missaoRepository.GetByIdAsync(missaoId);
        if(missao == null)
            throw  new KeyNotFoundException("MISSAO not found");
        
        missao.Uodate(request.Titulo, request.Descricao);
        
        await missaoRepository.UpdateAsync(missao);
        return true;
    }
}