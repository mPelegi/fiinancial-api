namespace Fiinancial.Api.Infrastructure.Generic.Repository
{
    public interface IGenericRepository<TEntity>
    {
        #region Sync Methods

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllReadOnly();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void MassInsert(List<TEntity> entities);
        void MassInsert(ICollection<TEntity> entities);
        void MassInsert(IQueryable<TEntity> entities);
        void Delete(TEntity entity);
        void Attach(TEntity entity);
        void MassDelete(List<TEntity> entities);
        void MassDelete(ICollection<TEntity> entities);
        void MassDelete(IQueryable<TEntity> entities);
        void Update(TEntity entity, string propertyName);
        void Update(TEntity entity, string[] propertyName);

        #endregion

        #region Async Methods

        Task<TEntity> GetByIdAsync(int id, CancellationToken ct = default);
        Task<TEntity> GetByIdAsync(long id, CancellationToken ct = default);
        Task InsertAsync(TEntity entity, CancellationToken ct = default);
        Task MassInsertAsync(List<TEntity> entity, CancellationToken ct = default);
        Task MassInsertAsync(ICollection<TEntity> entity, CancellationToken ct = default);
        Task MassInsertAsync(IQueryable<TEntity> entity, CancellationToken ct = default);

        #endregion
    }
}
