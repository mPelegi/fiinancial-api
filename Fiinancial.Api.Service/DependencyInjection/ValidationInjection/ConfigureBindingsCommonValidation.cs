using Fiinancial.Api.Service.Validations.Module.ContaCtx;
using Fiinancial.Api.Service.Validations.Module.GeralCtx;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection.ValidationInjection
{
    public static class ConfigureBindingsCommonValidation
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            #region Conta

            services.AddScoped<ContaValidator>();
            services.AddScoped<SituacaoPagamentoValidator>();
            services.AddScoped<TipoContaValidator>();

            #endregion

            #region Geral

            services.AddScoped<FrequenciaValidator>();
            services.AddScoped<UsuarioValidator>();

            #endregion

        }
    }
}
