using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces
{
    public interface IFrequenciaUnitOfWork : IGenericUnitOfWork
    {
        public IFrequenciaRepository FrequenciaRepository { get; }
    }
}
