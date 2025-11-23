using System.ComponentModel.DataAnnotations;

namespace PerifaFlowReal.Application.Dtos.Request;

public class TrilhaRequest
{
    [Required(ErrorMessage = "Titulo é necessário")]
    public string Titulo {get; set;}
    
    [Required(ErrorMessage = "Descrição é necessária")]
    public string Descricao { get; set; }
}