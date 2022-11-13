using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Infrastructure.Generic.Repository
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        #region Sync Methods

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> GetAllReadOnly()
        {
            return _dbSet.AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(new object[] { id });
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void MassInsert(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public virtual void MassInsert(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public virtual void MassInsert(IQueryable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(TEntity entity, string propertyName)
        {
            _context.Entry(entity).Property(propertyName).IsModified = true;
        }

        public void Update(TEntity entity, string[] propertiesNames)
        {
            if (propertiesNames != null && propertiesNames.Any())
            {
                foreach (var property in propertiesNames)
                {
                    Update(entity, property);
                }
            }
        }

        public virtual void Attach(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void MassDelete(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void MassDelete(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void MassDelete(IQueryable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        #endregion

        #region Async Methods

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _dbSet.AddAsync(entity, ct);
        }

        public virtual async Task MassInsertAsync(List<TEntity> entities, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _dbSet.AddRangeAsync(entities, ct);
        }
        public virtual async Task MassInsertAsync(ICollection<TEntity> entities, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _dbSet.AddRangeAsync(entities, ct);
        }
        public virtual async Task MassInsertAsync(IQueryable<TEntity> entities, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _dbSet.AddRangeAsync(entities, ct);
        }

        #endregion
    }
}
