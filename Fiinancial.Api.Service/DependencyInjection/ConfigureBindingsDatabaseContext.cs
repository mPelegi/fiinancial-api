using Fiinancial.Api.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection
{
    public static class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContextPool<FiinancialModel>(
                        options => options.UseSqlServer(configuration.GetConnectionString("FiinancialServer")).EnableSensitiveDataLogging()
                );
        }
    }
}
