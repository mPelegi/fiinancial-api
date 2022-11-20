using Fiinancial.Api.Crosscutting.DTO.ContaCtx;
using Fiinancial.Api.Crosscutting.DTO.GeralCtx;
using Fiinancial.Api.Service.Modules.Module.GeralCtx.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Fiinancial.Api.Interface.Controllers.GeralCtx
{
    /// <summary>
    /// Controller de Indicador
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _appService;

        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        public UsuarioController(IUsuarioApplicationService appService) => _appService = appService;

        /// <summary>
        /// Busca da Lista de Usuários.
        /// </summary>
        [HttpGet("filter")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Listagem de Usuários.", typeof(ICollection<UsuarioGetDto>))]
        public async Task<IActionResult> Filter(CancellationToken ct) => Ok(await _appService.Find(ct));

        /// <summary>
        /// Busca de um Usuário através de um Id de entrada.
        /// </summary>
        [HttpGet("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Dados do Usuário buscado.", typeof(UsuarioGetDto))]
        public async Task<IActionResult> GetById(int id, CancellationToken ct) => Ok(await _appService.Get(id, ct));

        /// <summary>
        /// Criação de um Usuário através de um DTO de entrada.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "Usuário criado com sucesso.", typeof(int))]
        public async Task<IActionResult> Create([FromBody] UsuarioPostDto dto, CancellationToken ct) => Ok(await _appService.Create(dto, ct));

        /// <summary>
        /// Edição de um Usuário através de um DTO de entrada.
        /// </summary>
        [HttpPut("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Usuário atualizado com sucesso.", typeof(int))]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioPutDto dto, CancellationToken ct) => Ok(await _appService.Update(id, dto, ct));

        /// <summary>
        /// Exclusão de um Usuário através de um Id de entrada.
        /// </summary>
        [HttpDelete("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Usuário excluído com sucesso.")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _appService.Delete(id, ct);
            return NoContent();
        }
    }
}
