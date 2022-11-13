using Fiinancial.Api.Crosscutting.DTO.ContaCtx;

namespace Fiinancial.Api.Service.Modules.Module.ContaCtx.Interfaces
{
    public interface IContaApplicationService
    {
        Task<ICollection<ContaGetDto>> Find(CancellationToken ct = default);
        Task<ContaGetDto> Get(int id, CancellationToken ct = default);
        Task<int> Create(ContaPostDto dto, CancellationToken ct = default);
        Task<int> Update(int id, ContaPutDto dto, CancellationToken ct = default);
        Task Delete(int id, CancellationToken ct = default);
        Task Delete(IEnumerable<int> ids, CancellationToken ct = default);
    }
}
