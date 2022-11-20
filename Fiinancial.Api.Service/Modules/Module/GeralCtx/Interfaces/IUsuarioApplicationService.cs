using Fiinancial.Api.Crosscutting.DTO.GeralCtx;

namespace Fiinancial.Api.Service.Modules.Module.GeralCtx.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task<ICollection<UsuarioGetDto>> Find(CancellationToken ct = default);
        Task<UsuarioGetDto> Get(int id, CancellationToken ct = default);
        Task<int> Create(UsuarioPostDto dto, CancellationToken ct = default);
        Task<int> Update(int id, UsuarioPutDto dto, CancellationToken ct = default);
        Task Delete(int id, CancellationToken ct = default);
    }
}
