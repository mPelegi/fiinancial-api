using Fiinancial.Api.Service.Mappers.ContaCtx;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection.MapperInjection
{
    public static class ConfigureBindingsCommonMapper
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            #region Conta

            services.AddScoped<ContaMapper>();

            #endregion
        }
    }
}
