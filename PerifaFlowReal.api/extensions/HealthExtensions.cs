namespace PerifaFlowReal.api.extensions;

public static class HealthExtensions
{
    public static IServiceCollection AddHealthServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddUrlGroup(new Uri("https://perifaflow-bemestar-java.onrender.com"), "Java");
        
        return services;
    }
}