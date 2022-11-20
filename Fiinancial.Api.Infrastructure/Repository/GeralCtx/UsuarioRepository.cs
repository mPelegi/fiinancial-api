using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Infrastructure.Generic.Repository;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.Repository.GeralCtx
{
    public class UsuarioRepository : GenericRepository<Usuario, FiinancialModel>, IUsuarioRepository
    {
        public UsuarioRepository(FiinancialModel context) : base(context)
        {
        }
    }
}
