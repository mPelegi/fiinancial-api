using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx
{
    public class SituacaoPagamentoUnitOfWork : GenericUnitOfWork, ISituacaoPagamentoUnitOfWork
    {
        public ISituacaoPagamentoRepository SituacaoPagamentoRepository =>
            _serviceProvider.GetService<ISituacaoPagamentoRepository>();

        public SituacaoPagamentoUnitOfWork(FiinancialModel context, IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}
