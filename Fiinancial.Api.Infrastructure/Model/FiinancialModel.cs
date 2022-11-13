using Fiinancial.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Infrastructure.Model
{
    public partial class FiinancialModel : GenericContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public FiinancialModel(DbContextOptions<FiinancialModel> options)
            : base(options)
        {
        }
    }
}
