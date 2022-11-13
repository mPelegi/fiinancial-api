using System.Data;

namespace Fiinancial.Api.Infrastructure.Context
{
    public interface IDatabaseContext
    {
        IDbConnection GetConnection();
    }
}
