using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Interfaces.Repositories;
using PerifaFlowReal.Application.UseCases.CreateMissaoUseCase;

namespace PerifaFlowReal.Application.UseCases;

public class UpdateTrilhaUseCase(ITrilhaRepository trilhaRepository) : IUpdateTrilhaUseCase
{
    public async Task<bool> Execute(Guid trilhaId, TrilhaRequest request)
    {
        var trilha = await trilhaRepository.GetByIdAsync(trilhaId);
        if(trilha == null)
            throw  new KeyNotFoundException("MISSAO not found");
        
        trilha.Update(request.Titulo, request.Descricao);
        
        await trilhaRepository.UpdateAsync(trilha);
        return true;
    }
}