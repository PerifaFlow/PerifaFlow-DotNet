using Microsoft.OpenApi.Models;

namespace PerifaFlowReal.Application.Configs;

public class SwaggerSettings
{
    public string Title { get; init; }

    public string Description { get; init; }
    
    public string Version { get; init; }

    public OpenApiContact Contact { get; set; }
}