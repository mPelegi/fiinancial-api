using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiinancial.Api.Domain.Entities.ContaCtx
{
    [Table("SituacaoPagamento")]
    public class SituacaoPagamento
    {
        [Key]
        [Column("IdSituacaoPagamento")]
        public int Id { get; set; }

        [Column("Nome")]
        [StringLength(30)]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Conta> Conta { get; set; }
    }
}
