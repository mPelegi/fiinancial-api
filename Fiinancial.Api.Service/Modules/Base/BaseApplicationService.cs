using Fiinancial.Api.Infrastructure.Generic.Repository;
using Fiinancial.Api.Infrastructure.Generic.UnitOfWork;
using Fiinancial.Api.Service.Validations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fiinancial.Api.Service.Modules.Base
{
    public class BaseApplicationService<TUnitOfWork, TRepository, TEntity>
        where TUnitOfWork : IGenericUnitOfWork
        where TRepository : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected TUnitOfWork _uow;

        private IGenericRepository<TEntity> Repository
        {
            get
            {
                var property = _uow.GetType().GetProperty(typeof(TRepository).Name.Substring(1));
                return property.GetValue(_uow) as IGenericRepository<TEntity>;
            }
        }

        protected BaseApplicationService(TUnitOfWork uow)
        {
            _uow = uow;
        }

        protected async Task<TEntity> ObterEntidade(int id)
        {
            var entidade = await Repository.GetByIdAsync(id);
            if (entidade == null)
                throw new Exception("O registro não foi encontrado.");

            return entidade;
        }

        protected void Existe(TEntity entidade)
        {
            if (entidade == null) throw new Exception("O registro não foi encontrado");
        }

        protected void Existe(TEntity entidade, string nome)
        {
            if (entidade == null) throw new Exception($"{nome} não foi encontrado");
        }

        protected void Existe(object dto)
        {
            if (dto == null) throw new Exception("O registro não foi encontrado");
        }

        protected async Task Validate(TEntity entidade, BaseValidator<TEntity> validator)
        {
            var validacaoEntidade = await validator.ValidateAsync(entidade);
            if (!validacaoEntidade.IsValid)
                throw new Exception(validacaoEntidade.Errors.FirstOrDefault().ErrorMessage);
        }

        public virtual async Task Remover(int id)
        {
            var entity = await ObterEntidade(id);
            Repository.Delete(entity);
            await _uow.CommitAsync();
        }

        public virtual async Task RemoverLista(List<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = await ObterEntidade(id);
                Repository.Delete(entity);
            }

            await _uow.CommitAsync();
        }

        private PropertyInfo VerificarPropriedade(object entidade, string prop)
        {
            var tipo = entidade.GetType();
            var propriedade = tipo.GetProperty(prop);

            if (propriedade == null) throw new Exception($"O objeto não possui a propriedade '{prop}'.");

            return propriedade;
        }
    }
}
