using Fiinancial.Api.Domain.Entities.ContaCtx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Infrastructure.Map.ContaCtx
{
    public class SituacaoPagamentoMap : IEntityTypeConfiguration<SituacaoPagamento>
    {
        public void Configure(EntityTypeBuilder<SituacaoPagamento> builder)
        {
        }
    }
}
