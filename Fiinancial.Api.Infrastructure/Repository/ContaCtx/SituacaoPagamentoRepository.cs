using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Infrastructure.Generic.Repository;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.Repository.ContaCtx
{
    public class SituacaoPagamentoRepository : GenericRepository<SituacaoPagamento, FiinancialModel>, ISituacaoPagamentoRepository
    {
        public SituacaoPagamentoRepository(FiinancialModel context) : base(context)
        {
        }
    }
}
