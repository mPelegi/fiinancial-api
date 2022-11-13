using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Infrastructure.Model
{
    public partial class FiinancialModel : GenericContext
    {
        public DbSet<Conta> Conta { get; set; }
        public DbSet<SituacaoPagamento> SituacaoPagamento { get; set; }
        public DbSet<TipoConta> TipoConta { get; set; }
    }
}
