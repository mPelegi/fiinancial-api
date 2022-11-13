using Fiinancial.Api.Domain.Entities.GeralCtx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiinancial.Api.Infrastructure.Map.GeralCtx
{
    public class FrequenciaMap : IEntityTypeConfiguration<Frequencia>
    {
        public void Configure(EntityTypeBuilder<Frequencia> builder)
        {
        }
    }
}
