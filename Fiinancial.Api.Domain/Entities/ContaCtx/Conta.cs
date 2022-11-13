using Fiinancial.Api.Domain.Entities.GeralCtx;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiinancial.Api.Domain.Entities.ContaCtx
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        [Column("IdConta")]
        public int Id { get; set; }

        [Column("FK_IdTipoConta")]
        public int IdTipoConta { get; set; }

        [Column("FK_IdFrequencia")]
        public int IdFrequencia { get; set; }

        [Column("FK_IdSituacaoPagamento")]
        public int IdSituacaoPagamento { get; set; }

        [Column("Valor")]
        public decimal Valor { get; set; }

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("DataAbertura")]
        public DateTime? DataAbertura { get; set; }

        [Column("DataVencimento")]
        public DateTime? DataVencimento { get; set; }

        [Column("DataPagamento")]
        public DateTime? DataPagamento { get; set; }

        [JsonIgnore]
        public TipoConta TipoConta { get; set; } = new TipoConta();

        [JsonIgnore]
        public Frequencia Frequencia { get; set; } = new Frequencia();

        [JsonIgnore]
        public SituacaoPagamento SituacaoPagamento { get; set; } = new SituacaoPagamento();
    }
}
