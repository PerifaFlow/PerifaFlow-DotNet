using Moq;
using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Interfaces.Services;
using PerifaFlowReal.Application.UseCases.Java.RegistrarRitimoUseCase;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public async Task ExecuteAsync_ChamaServicoRegistrarAsync()
    {
        // Arrange
        var mockService = new Mock<IRitimoService>();

        // Configura o mock para apenas retornar Task.CompletedTask quando chamado
        mockService
            .Setup(s => s.RegistrarAsync(It.IsAny<RitmoRegistroDto>(), It.IsAny<string?>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var useCase = new RegistrarRitimoUseCase(mockService.Object);

        var dto = new RitmoRegistroDto
        {
            Bairro = "Centro",
            Turno = "MANHA",
            Energia = 1,
            Ambiente = 1,
            Condicao = 1,
            OptIn = true
        };

        // Act
        await useCase.ExecuteAsync(dto, "fake-token");

        // Assert
        mockService.Verify(
            s => s.RegistrarAsync(dto, "fake-token", It.IsAny<CancellationToken>()),
            Times.Once
        );
    }
}