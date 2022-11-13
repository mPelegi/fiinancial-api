using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Infrastructure.Context
{
    public class GenericContext : DbContext
    {
        public GenericContext(DbContextOptions options)
        : base(options)
        {
            Database.SetCommandTimeout(36000);
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        #region Sync Methods
        public int ExecuteSqlCommand(string command)
        {
            return Database.ExecuteSqlRaw(command);
        }

        public int ExecuteSqlCommand(string command, params object[] parameters)
        {
            return Database.ExecuteSqlRaw(command, parameters);
        }

        #endregion

        #region Async Methods

        public async Task<int> ExecuteSqlCommandAsync(string command, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await Database.ExecuteSqlRawAsync(command, ct);
        }

        public async Task<int> ExecuteSqlCommandAsync(string command, CancellationToken ct = default, params object[] parameters)
        {
            ct.ThrowIfCancellationRequested();

            return await Database.ExecuteSqlRawAsync(command, parameters);
        }

        #endregion
    }
}
