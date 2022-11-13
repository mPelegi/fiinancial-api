using Fiinancial.Api.Domain.Entities.ContaCtx;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiinancial.Api.Domain.Entities.GeralCtx
{
    [Table("Frequencia")]
    public class Frequencia
    {
        [Key]
        [Column("IdFrequencia")]
        public int Id { get; set; }

        [Column("Nome")]
        [StringLength(30)]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Column("IntervaloDias")]
        public int IntervaloDias { get; set; }

        [JsonIgnore]
        public ICollection<Conta> Conta { get; set; }
    }
}
