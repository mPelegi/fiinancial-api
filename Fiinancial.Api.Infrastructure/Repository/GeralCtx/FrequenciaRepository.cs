using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Infrastructure.Generic.Repository;
using Fiinancial.Api.Infrastructure.Model;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;

namespace Fiinancial.Api.Infrastructure.Repository.GeralCtx
{
    public class FrequenciaRepository : GenericRepository<Frequencia, FiinancialModel>, IFrequenciaRepository
    {
        public FrequenciaRepository(FiinancialModel context) : base(context)
        {
        }
    }
}
