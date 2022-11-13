using Fiinancial.Api.Infrastructure.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Fiinancial.Api.Infrastructure.Context
{
    public sealed class FiinancialModelContext : IDatabaseContext
    {
        private readonly FiinancialModel _context;

        public FiinancialModelContext(FiinancialModel context)
        {
            _context = context;
        }

        public IDbConnection GetConnection() =>
                new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
    }
}
