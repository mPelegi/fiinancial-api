using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiinancial.Api.Domain.Entities.ContaCtx
{
    [Table("TipoConta")]
    public class TipoConta
    {
        [Key]
        [Column("IdTipoConta")]
        public int Id { get; set; }

        [Column("Nome")]
        [StringLength(30)]
        public string Nome { get; set; } = string.Empty;

        [Column("Descricao")]
        [StringLength(100)]
        public string Descricao { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Conta> Conta { get; set; } = new List<Conta>();
    }
}
