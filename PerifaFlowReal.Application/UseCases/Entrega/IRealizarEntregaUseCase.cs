using PerifaFlow.Domain.Entities;
using PerifaFlowReal.Application.Dtos.Request;

namespace PerifaFlowReal.Application.UseCases;

public interface IRealizarEntregaUseCase
{
    Task RealizarEntrega(EntregaRequest request);
}