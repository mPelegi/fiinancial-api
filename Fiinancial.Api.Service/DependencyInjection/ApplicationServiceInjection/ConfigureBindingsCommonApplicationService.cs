using Fiinancial.Api.Service.Modules.Module.ContaCtx;
using Fiinancial.Api.Service.Modules.Module.ContaCtx.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection.ApplicationServiceInjection
{
    public class ConfigureBindingsCommonApplicationService
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            #region Conta

            services.AddScoped<IContaApplicationService, ContaApplicationService>();

            #endregion
        }
    }
}
