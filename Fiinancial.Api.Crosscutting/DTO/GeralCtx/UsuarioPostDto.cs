namespace Fiinancial.Api.Crosscutting.DTO.GeralCtx
{
    public class UsuarioPostDto
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
    }
}
