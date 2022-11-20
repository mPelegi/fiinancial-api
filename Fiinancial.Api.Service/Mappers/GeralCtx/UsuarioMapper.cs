using Fiinancial.Api.Crosscutting.DTO.GeralCtx;
using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Service.Utils;

namespace Fiinancial.Api.Service.Mappers.GeralCtx
{
    public class UsuarioMapper
    {
        public Usuario MapearEntidade(UsuarioPostDto dto)
        {
            return new Usuario
            {
                Email = dto.Email,
                Nome = dto.Nome,
                Senha = dto.Senha.ToSha512(),
                Administrador = dto.Administrador
            };
        }

        public void MapearEntidade(Usuario entidade, UsuarioPutDto dto)
        {
            entidade.Nome = dto.Nome;
            entidade.Senha = dto.Senha;
            entidade.Administrador = dto.Administrador;
        }
    }
}
