using Fiinancial.Api.Service.Modules.Module.ContaCtx;
using Fiinancial.Api.Service.Modules.Module.ContaCtx.Interfaces;
using Fiinancial.Api.Service.Modules.Module.GeralCtx;
using Fiinancial.Api.Service.Modules.Module.GeralCtx.Interfaces;
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

            #region Geral

            services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
            services.AddScoped<ILoginApplicationService, LoginApplicationService>();

            #endregion
        }
    }
}
