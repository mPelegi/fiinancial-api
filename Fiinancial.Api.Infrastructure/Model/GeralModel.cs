using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Infrastructure.Model
{
    public partial class FiinancialModel : GenericContext
    {
        public DbSet<Frequencia> Frequencia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
