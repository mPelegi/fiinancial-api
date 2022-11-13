using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Infrastructure.Generic.Repository;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.Repository.ContaCtx
{
    public class TipoContaRepository : GenericRepository<TipoConta, FiinancialModel>, ITipoContaRepository
    {
        public TipoContaRepository(FiinancialModel context) : base(context)
        {
        }
    }
}
