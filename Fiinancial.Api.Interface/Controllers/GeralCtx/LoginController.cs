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
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplicationService _appService;

        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        public LoginController(ILoginApplicationService appService) => _appService = appService;

        /// <summary>
        /// Login através de um DTO de entrada.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "Login realizado com sucesso.", typeof(LoggedDto))]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct) => Ok(await _appService.Authenticate(dto, ct));
    }
}
