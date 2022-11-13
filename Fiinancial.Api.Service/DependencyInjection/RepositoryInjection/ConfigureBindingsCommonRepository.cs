using Fiinancial.Api.Infrastructure.Context;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection.RepositoryInjection
{
    public static class ConfigureBindingsCommonRepository
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            #region Configuração

            services.AddScoped<IDatabaseContext, FiinancialModelContext>();

            #endregion

            #region Conta

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ITipoContaRepository, TipoContaRepository>();
            services.AddScoped<ISituacaoPagamentoRepository, SituacaoPagamentoRepository>();

            #endregion

            #region Geral

            services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();

            #endregion

        }
    }
}
