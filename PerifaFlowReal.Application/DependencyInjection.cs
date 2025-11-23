using Microsoft.Extensions.DependencyInjection;
using PerifaFlowReal.Application.UseCases;
using PerifaFlowReal.Application.UseCases.CreateMissaoUseCase;
using PerifaFlowReal.Application.UseCases.CreateUserUseCase;
using PerifaFlowReal.Application.UseCases.Java.RegistrarRitimoUseCase;
using PerifaFlowReal.Application.UseCases.Login;
using PerifaFlowReal.Application.UseCases.ObterInsightUseCase;
using PerifaFlowReal.Application.UseCases.PortFolio;
using PerifaFlowReal.Application.UseCases.SugestaoMissaoUseCase;

namespace PerifaFlowReal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<ICreateMissaoUseCase, CreateMissaoUseCase>();
        services.AddScoped<IRealizarEntregaUseCase, RealizarEntregaUseCase>();
        services.AddScoped<ObterInsightUseCase>();
        services.AddScoped<RegistrarRitimoUseCase>();
        services.AddScoped<SugerirMissaoUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<ICreatePortfolioUseCase, CreatePortFolio>();
        services.AddScoped<ITrilhaUseCase, TrilhaUseCase>();
        
        return services;
    }
}