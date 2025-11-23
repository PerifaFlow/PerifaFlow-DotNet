using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Interfaces.Repositories;

namespace PerifaFlowReal.Application.UseCases;

public class RealizarEntregaUseCase(IEntregaRepository entregaRepository): IRealizarEntregaUseCase
{
    public async Task RealizarEntrega(EntregaRequest request)
    {
        // 1. Validar request manualmente (já tem [Required], mas isso é do MVC)
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (request.UseroId == Guid.Empty)
            throw new ArgumentException("Usuário inválido.");

        if (request.MissaoId == Guid.Empty)
            throw new ArgumentException("Missão inválida.");

        if (string.IsNullOrWhiteSpace(request.ConteudoUrl))
            throw new ArgumentException("Conteúdo da URL é obrigatório.");

        // 2. Criar entidade da Entrega
        var entrega = new Entrega
        (
            request.Tipo,
            request.ConteudoUrl,
            request.UseroId,
            request.MissaoId
        );

        // 3. Persistir através do repositório genérico
        await entregaRepository.AddAsync(entrega);
    }
}