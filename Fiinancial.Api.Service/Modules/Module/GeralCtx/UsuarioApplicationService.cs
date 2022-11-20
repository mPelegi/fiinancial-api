using Fiinancial.Api.Crosscutting.DTO.GeralCtx;
using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Infrastructure.Repository.GeralCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.GeralCtx.Interfaces;
using Fiinancial.Api.Service.Mappers.GeralCtx;
using Fiinancial.Api.Service.Modules.Base;
using Fiinancial.Api.Service.Modules.Module.GeralCtx.Interfaces;
using Fiinancial.Api.Service.Utils;
using Fiinancial.Api.Service.Validations.Module.GeralCtx;
using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Service.Modules.Module.GeralCtx
{
    public class UsuarioApplicationService : BaseApplicationService<IUsuarioUnitOfWork, IUsuarioRepository, Usuario>, IUsuarioApplicationService
    {
        private readonly UsuarioMapper _mapper;
        private readonly UsuarioValidator _validator;

        public UsuarioApplicationService(IUsuarioUnitOfWork uow, UsuarioMapper mapper, UsuarioValidator validator) : base(uow)
        {
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Create(UsuarioPostDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Usuario usuario = _mapper.MapearEntidade(dto);

            await Validate(usuario, _validator);

            _uow.UsuarioRepository.Insert(usuario);
            await _uow.CommitAsync();

            return usuario.Id;
        }

        public async Task Delete(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Usuario usuario = await _uow.UsuarioRepository.GetByIdAsync(id, ct);

            if (usuario == null) throw new Exception("Registro não encontrado.");

            _uow.UsuarioRepository.Delete(usuario);
            await _uow.CommitAsync();
        }

        public async Task Delete(IEnumerable<int> ids, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            if (ids.Any())
            {
                foreach (int id in ids)
                {
                    await Delete(id, ct);
                }
            }
        }

        public async Task<ICollection<UsuarioGetDto>> Find(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var usuarioQuery = _uow.UsuarioRepository.GetAllReadOnly();
            var usuarios = await usuarioQuery.ToListAsync(ct);
            var response = new List<UsuarioGetDto>();

            foreach (var usuario in usuarios)
            {
                response.Add(new UsuarioGetDto
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Administrador = usuario.Administrador,
                });
            }

            return response;
        }

        public async Task<UsuarioGetDto> Get(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Usuario usuario = await _uow.UsuarioRepository.GetByIdAsync(id, ct);

            if (usuario == null) throw new Exception("Registro não encontrado.");

            return new UsuarioGetDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Administrador = usuario.Administrador,
            };
        }

        public async Task<int> Update(int id, UsuarioPutDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Usuario usuario = await _uow.UsuarioRepository.GetByIdAsync(id, ct);

            if (usuario == null) throw new Exception("Registro não encontrado.");

            _mapper.MapearEntidade(usuario, dto);

            await Validate(usuario, _validator);

            await _uow.CommitAsync();

            return usuario.Id;
        }
    }
}
