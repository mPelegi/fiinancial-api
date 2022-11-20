namespace Fiinancial.Api.Crosscutting.DTO.GeralCtx
{
    public class UsuarioGetDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public bool Administrador { get; set; }
    }
}
