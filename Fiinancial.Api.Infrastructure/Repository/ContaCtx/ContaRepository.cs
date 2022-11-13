using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Infrastructure.Generic.Repository;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.Repository.ContaCtx
{
    public class ContaRepository : GenericRepository<Conta, FiinancialModel>, IContaRepository
    {
        public ContaRepository(FiinancialModel context) : base(context)
        {
        }
    }
}