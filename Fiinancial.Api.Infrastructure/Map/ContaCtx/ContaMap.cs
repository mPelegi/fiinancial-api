using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fiinancial.Api.Domain.Entities.ContaCtx;

namespace Fiinancial.Api.Infrastructure.Map.ContaCtx
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.Property(x => x.DataCriacao)
                .HasColumnType("datetime2");

            builder.Property(x => x.DataAbertura)
                .HasColumnType("datetime2");

            builder.Property(x => x.DataVencimento)
                .HasColumnType("datetime2");

            builder.Property(x => x.DataPagamento)
                .HasColumnType("datetime2");

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(10,5)");

            builder.HasOne(x => x.TipoConta)
                .WithMany(x => x.Conta)
                .HasForeignKey(x => x.IdTipoConta);

            builder.HasOne(x => x.SituacaoPagamento)
                .WithMany(x => x.Conta)
                .HasForeignKey(x => x.IdSituacaoPagamento);

            builder.HasOne(x => x.Frequencia)
                .WithMany(x => x.Conta)
                .HasForeignKey(x => x.IdFrequencia);

        }
    }
}
