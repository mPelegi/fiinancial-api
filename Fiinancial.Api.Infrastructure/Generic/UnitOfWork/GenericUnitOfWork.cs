using Fiinancial.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Fiinancial.Api.Infrastructure.Generic.UnitOfWork
{
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        private List<Action> _afterCommitActions = new List<Action>();
        protected readonly IServiceProvider _serviceProvider;
        private readonly bool _commitSPID;

        protected GenericContext Context { get; set; }

        public GenericUnitOfWork(GenericContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            _serviceProvider = serviceProvider;
        }

        public GenericUnitOfWork(GenericContext _context)
        {
            Context = _context;
        }

        public virtual void Commit()
        {
            Context.ChangeTracker.DetectChanges();
            FinishCommit();
        }

        public virtual Task CommitAsync()
        {
            Context.ChangeTracker.DetectChanges();
            return FinishCommitAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            Context.ChangeTracker.DetectChanges();
            await Context.SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Context.ChangeTracker.DetectChanges();
            await Context.SaveChangesAsync(cancellationToken);
        }

        public void UndoChanges()
        {
            Context.ChangeTracker.DetectChanges();

            var changedEntries = Context.ChangeTracker.Entries()
                                                      .Where(x => x.State != EntityState.Unchanged)
                                                      .ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public virtual Task CommitOnlyChangedPropertiesAsync()
        {
            return FinishCommitAsync();
        }

        protected virtual async Task FinishCommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
                InvokeAfterCommitActions();
            }
            catch (DbUpdateException dbExeception)
            {
                HandleDbUpdateException(dbExeception);
                return;
            }
        }

        protected virtual void FinishCommit()
        {
            try
            {
                Context.SaveChanges();

                InvokeAfterCommitActions();
            }
            catch (DbUpdateException dbException)
            {
                throw dbException;
            }
        }

        private static string HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");
            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e);
            }
            return builder.ToString();
        }

        public void InvokeAfterCommitActions()
        {
            _afterCommitActions.ForEach(action => action.Invoke());
        }

        public DatabaseFacade Database
        {
            get { return Context.Database; }
        }

        public void EnableValidations(bool enabled)
        {
            Context.ChangeTracker.AutoDetectChangesEnabled = enabled;
        }

        public async Task<IDbContextTransaction> BeginTransaction() => await Context.Database.BeginTransactionAsync();

        public void CommitAsyncWithException()
        {
            try
            {
                Context.ChangeTracker.DetectChanges();
                Context.SaveChanges();
            }
            catch (DbUpdateException dbException)
            {
                throw dbException;
            }
        }
    }
}
