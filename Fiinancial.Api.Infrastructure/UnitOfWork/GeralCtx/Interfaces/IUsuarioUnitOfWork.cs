using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces
{
    public interface IUsuarioUnitOfWork : IGenericUnitOfWork
    {
        public IUsuarioRepository UsuarioRepository { get; }
    }
}
