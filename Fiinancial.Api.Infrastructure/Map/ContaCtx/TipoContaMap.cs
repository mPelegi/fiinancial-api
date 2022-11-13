using Fiinancial.Api.Domain.Entities.ContaCtx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiinancial.Api.Infrastructure.Map.ContaCtx
{
    public class TipoContaMap : IEntityTypeConfiguration<TipoConta>
    {
        public void Configure(EntityTypeBuilder<TipoConta> builder)
        {
        }
    }
}
