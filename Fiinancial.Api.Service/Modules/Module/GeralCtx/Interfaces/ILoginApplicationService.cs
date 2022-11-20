using Fiinancial.Api.Crosscutting.DTO.GeralCtx;
using Fiinancial.Api.Domain.Entities.GeralCtx;

namespace Fiinancial.Api.Service.Modules.Module.GeralCtx.Interfaces
{
    public interface ILoginApplicationService
    {
        string GerarToken(Usuario usuario, CancellationToken ct = default);
        Task<LoggedDto> Authenticate(LoginDto dto, CancellationToken ct = default);
    }
}
