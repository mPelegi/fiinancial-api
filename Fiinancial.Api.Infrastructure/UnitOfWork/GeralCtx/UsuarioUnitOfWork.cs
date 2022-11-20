using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx
{
    public class UsuarioUnitOfWork : GenericUnitOfWork, IUsuarioUnitOfWork
    {
        public IUsuarioRepository UsuarioRepository =>
            _serviceProvider.GetService<IUsuarioRepository>();

        public UsuarioUnitOfWork(FiinancialModel context, IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}
