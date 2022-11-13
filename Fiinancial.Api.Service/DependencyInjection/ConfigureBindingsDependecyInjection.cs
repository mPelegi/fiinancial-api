using Fiinancial.Api.Service.DependencyInjection.ApplicationServiceInjection;
using Fiinancial.Api.Service.DependencyInjection.MapperInjection;
using Fiinancial.Api.Service.DependencyInjection.RepositoryInjection;
using Fiinancial.Api.Service.DependencyInjection.UnitOfWorkInjection;
using Fiinancial.Api.Service.DependencyInjection.ValidationInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiinancial.Api.Service.DependencyInjection
{
    public static class ConfigureBindingsDependecyInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsDatabaseContext.RegisterBindings(services, configuration);

            #region Application Service

            ConfigureBindingsCommonApplicationService.RegisterBindings(services);

            #endregion

            #region Repository

            ConfigureBindingsCommonRepository.RegisterBindings(services);

            #endregion

            #region Unit Of Work

            ConfigureBindingsCommonUnitOfWork.RegisterBindings(services);

            #endregion

            #region Mapper

            ConfigureBindingsCommonMapper.RegisterBindings(services);

            #endregion

            #region Validation

            ConfigureBindingsCommonValidation.RegisterBindings(services);

            #endregion
        }
    }
}
