namespace PerifaFlowReal.Application.Dtos.Response;

public class LinkResponse
{
    public string Rel { get; set; } = string.Empty;
    public string Href { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    
    public LinkResponse(string rel, string href, string method)
    {
        Rel = rel;
        Href = href;
        Method = method;
    }
}