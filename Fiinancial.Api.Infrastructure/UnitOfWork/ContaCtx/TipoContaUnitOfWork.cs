using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx
{
    public class TipoContaUnitOfWork : GenericUnitOfWork, ITipoContaUnitOfWork
    {
        public ITipoContaRepository TipoContaRepository =>
            _serviceProvider.GetService<ITipoContaRepository>();

        public TipoContaUnitOfWork(FiinancialModel context, IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}
