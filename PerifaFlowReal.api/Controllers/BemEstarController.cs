using Asp.Versioning;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerifaFlowReal.Application.Dtos.java;
using PerifaFlowReal.Application.Interfaces.Services;
using PerifaFlowReal.Application.UseCases.Java.RegistrarRitimoUseCase;
using PerifaFlowReal.Application.UseCases.ObterInsightUseCase;
using PerifaFlowReal.Application.UseCases.SugestaoMissaoUseCase;
using Swashbuckle.AspNetCore.Annotations;

namespace PerifaFlowReal.api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [SwaggerTag("Gerenciamento de Login")]
    [AllowAnonymous]
    [ApiController]
    public class BemEstarController : ControllerBase
    {
        private readonly RegistrarRitimoUseCase _registrarUseCase;
        private readonly ObterInsightUseCase _insightsUseCase;
        private readonly SugerirMissaoUseCase _missaoUseCase;

        public BemEstarController(
            RegistrarRitimoUseCase registrarUseCase,
            ObterInsightUseCase insightsUseCase,
            SugerirMissaoUseCase missaoUseCase)
        {
            _registrarUseCase = registrarUseCase;
            _insightsUseCase = insightsUseCase;
            _missaoUseCase = missaoUseCase;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RitmoRegistroDto dto, CancellationToken ct)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Bairro) || dto.Bairro.Length > 120)
                erros.Add("O campo 'bairro' é obrigatório e deve ter no máximo 120 caracteres.");

            if (!new[] { "MANHA", "TARDE", "NOITE" }.Contains(dto.Turno?.ToUpper()))
                erros.Add("O campo 'turno' deve ser MANHA, TARDE ou NOITE.");

            if (dto.Energia < 0 || dto.Energia > 2)
                erros.Add("O campo 'energia' deve ser entre 0 e 2.");

            if (dto.Ambiente < 0 || dto.Ambiente > 2)
                erros.Add("O campo 'ambiente' deve ser entre 0 e 2.");

            if (dto.Condicao < 0 || dto.Condicao > 2)
                erros.Add("O campo 'condicao' deve ser entre 0 e 2.");

            if (erros.Any())
                return BadRequest(new { message = "Dados inválidos.", errors = erros });

            string? token = Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            try
            {
                await _registrarUseCase.ExecuteAsync(dto, token, ct);
                return Ok(new { message = "Registro enviado ao serviço BemEstar" });
            }
            catch (Exception ex)
            {
                // Aqui você pode logar ex.Message ou ex.ToString() para debug
                return StatusCode(500, new { message = "Erro ao chamar a API Java.", details = ex.Message });
            }
        }
        

        [HttpGet("insights")]
        public async Task<IActionResult> Insights(string bairro, DateTime de, DateTime ate)
        {
            string? token = Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var result = await _insightsUseCase.ExecuteAsync(bairro, de, ate, token);
            return Ok(result);
        }

        [HttpPost("sugerir-missao")]
        public async Task<IActionResult> SugerirMissao([FromBody] SugestaoMissaoRequest dto)
        {
            string? token = Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var result = await _missaoUseCase.ExecuteAsync(dto, token);
            return Ok(result);
        }
    }
}
