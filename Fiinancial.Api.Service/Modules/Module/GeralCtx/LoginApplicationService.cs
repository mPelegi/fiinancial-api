using Fiinancial.Api.Crosscutting.DTO.GeralCtx;
using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces;
using Fiinancial.Api.Service.Mappers.GeralCtx;
using Fiinancial.Api.Service.Modules.Base;
using Fiinancial.Api.Service.Modules.Module.GeralCtx.Interfaces;
using Fiinancial.Api.Service.Settings;
using Fiinancial.Api.Service.Utils;
using Fiinancial.Api.Service.Validations.Module.GeralCtx;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml;

namespace Fiinancial.Api.Service.Modules.Module.GeralCtx
{
    public class LoginApplicationService : BaseApplicationService<IUsuarioUnitOfWork, IUsuarioRepository, Usuario>, ILoginApplicationService
    {
        private readonly JwtSettings _jwt;
        private readonly UsuarioMapper _mapper;
        private readonly UsuarioValidator _validator;

        public LoginApplicationService(IUsuarioUnitOfWork uow, UsuarioMapper mapper, UsuarioValidator validator, IServiceProvider serviceProvider) : base(uow)
        {
            _jwt = serviceProvider.GetService<JwtSettings>();
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<LoggedDto> Authenticate(LoginDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Usuario usuario = await _uow.UsuarioRepository.GetAllReadOnly()
                .FirstOrDefaultAsync(u => u.Email.Equals(dto.Email) && u.Senha.Equals(dto.Senha.ToSha512()), ct);

            if (usuario == null) throw new Exception("Registro não encontrado.");

            return new LoggedDto(
                new UsuarioGetDto
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Administrador = usuario.Administrador,
                },
                GerarToken(usuario, ct)
            );
        }

        public string GerarToken(Usuario usuario, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.SigningCredentials.Key.ToString());

            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            }); ;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = _jwt.AccessTokenExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwt.Audience,
                Issuer = _jwt.Issuer,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
