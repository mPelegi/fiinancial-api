using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx.Interfaces
{
    public interface IContaUnitOfWork : IGenericUnitOfWork
    {
        IContaRepository ContaRepository { get; }
    }
}
