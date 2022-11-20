using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiinancial.Api.Crosscutting.DTO.GeralCtx
{
    public class LoggedDto
    {
        public LoggedDto(UsuarioGetDto usuario, string token)
        {
            Usuario = usuario;
            Token = token;
        }

        public UsuarioGetDto Usuario { get; set; }
        public string Token { get; set; }
    }
}
