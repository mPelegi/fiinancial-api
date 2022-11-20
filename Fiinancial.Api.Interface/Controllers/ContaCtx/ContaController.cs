using Fiinancial.Api.Crosscutting.DTO.ContaCtx;
using Fiinancial.Api.Service.Modules.Module.ContaCtx.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fiinancial.Api.Interface.Controllers.ContaCtx
{
    /// <summary>
    /// Controller de Indicador
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaApplicationService _appService;

        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        public ContaController(IContaApplicationService appService) => _appService = appService;

        /// <summary>
        /// Busca da Lista de Contas.
        /// </summary>
        [HttpGet("filter")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Listagem de Contas.", typeof(ICollection<ContaGetDto>))]
        public async Task<IActionResult> Filter(CancellationToken ct) => Ok(await _appService.Find(ct));

        /// <summary>
        /// Busca de uma Conta através de um Id de entrada.
        /// </summary>
        [HttpGet("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Dados da Conta buscada.", typeof(ContaGetDto))]
        public async Task<IActionResult> GetById(int id, CancellationToken ct) => Ok(await _appService.Get(id, ct));

        /// <summary>
        /// Criação de uma Conta através de um DTO de entrada.
        /// </summary>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "Conta criada com sucesso.", typeof(int))]
        public async Task<IActionResult> Create([FromBody] ContaPostDto dto, CancellationToken ct) => Ok(await _appService.Create(dto, ct));

        /// <summary>
        /// Edição de uma Conta através de um DTO de entrada.
        /// </summary>
        [HttpPut("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Conta atualizada com sucesso.", typeof(int))]
        public async Task<IActionResult> Update(int id, [FromBody] ContaPutDto dto, CancellationToken ct) => Ok(await _appService.Update(id, dto, ct));

        /// <summary>
        /// Exclusão de uma Conta através de um Id de entrada.
        /// </summary>
        [HttpDelete("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Conta excluída com sucesso.")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _appService.Delete(id, ct);
            return NoContent();
        }

        /// <summary>
        /// Exclusão em Massa de Contas.
        /// </summary>
        [HttpDelete("massDelete")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Contas excluídas com sucesso.")]
        public async Task<IActionResult> MassDelete([FromBody] List<int> ids, CancellationToken ct)
        {
            await _appService.Delete(ids, ct);
            return NoContent();
        }
    }
}
