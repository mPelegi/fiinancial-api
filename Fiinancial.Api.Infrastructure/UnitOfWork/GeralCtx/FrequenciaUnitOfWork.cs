using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx
{
    public class FrequenciaUnitOfWork : GenericUnitOfWork, IFrequenciaUnitOfWork
    {
        public IFrequenciaRepository FrequenciaRepository =>
            _serviceProvider.GetService<IFrequenciaRepository>();

        public FrequenciaUnitOfWork(FiinancialModel context, IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}
