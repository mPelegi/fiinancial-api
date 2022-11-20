using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiinancial.Api.Domain.Entities.GeralCtx
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("IdUsuario")]
        public int Id { get; set; }

        [Column("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("Nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("Senha")]
        [StringLength(255)]
        public string Senha { get; set; }

        [Column("Administrador")]
        public bool Administrador { get; set; }
    }
}
