using Microsoft.EntityFrameworkCore.Storage;

namespace Fiinancial.Api.Infrastructure.Generic.UnitOfWork
{
    public interface IGenericUnitOfWork
    {
        #region Sync Methods
        void Commit();

        #endregion

        #region Async Methods

        Task CommitAsync();
        void CommitAsyncWithException();
        Task CommitOnlyChangedPropertiesAsync();
        Task<IDbContextTransaction> BeginTransaction();

        #endregion
    }
}
