using Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx;
using Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection.UnitOfWorkInjection
{
    public static class ConfigureBindingsCommonUnitOfWork
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            #region Conta

            services.AddScoped<IContaUnitOfWork, ContaUnitOfWork>();
            services.AddScoped<ITipoContaUnitOfWork, TipoContaUnitOfWork>();
            services.AddScoped<ISituacaoPagamentoUnitOfWork, SituacaoPagamentoUnitOfWork>();

            #endregion

            #region Geral

            services.AddScoped<IFrequenciaUnitOfWork, FrequenciaUnitOfWork>();
            services.AddScoped<IUsuarioUnitOfWork, UsuarioUnitOfWork>();

            #endregion
        }
    }
}
