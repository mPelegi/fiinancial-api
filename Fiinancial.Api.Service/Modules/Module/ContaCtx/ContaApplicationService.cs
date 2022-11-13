using Fiinancial.Api.Crosscutting.DTO.ContaCtx;
using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Infrastructure.Repository.ContaCtx.Interfaces;
using Fiinancial.Api.Infrastructure.UnitOfWork.ContaCtx.Interfaces;
using Fiinancial.Api.Service.Mappers.ContaCtx;
using Fiinancial.Api.Service.Modules.Base;
using Fiinancial.Api.Service.Modules.Module.ContaCtx.Interfaces;
using Fiinancial.Api.Service.Validations.Module.ContaCtx;
using Microsoft.EntityFrameworkCore;

namespace Fiinancial.Api.Service.Modules.Module.ContaCtx
{
    public class ContaApplicationService : BaseApplicationService<IContaUnitOfWork, IContaRepository, Conta>, IContaApplicationService
    {
        private readonly ContaMapper _mapper;
        private readonly ContaValidator _validator;

        public ContaApplicationService(IContaUnitOfWork uow, ContaMapper mapper, ContaValidator validator) : base(uow)
        {
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Create(ContaPostDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Conta conta = _mapper.MapearEntidade(dto);

            conta.DataCriacao = DateTime.Now;

            await Validate(conta, _validator);

            _uow.ContaRepository.Insert(conta);
            await _uow.CommitAsync();

            return conta.Id;
        }

        public async Task Delete(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Conta conta = await _uow.ContaRepository.GetByIdAsync(id, ct);

            if (conta == null) throw new Exception("Registro não encontrado.");

            _uow.ContaRepository.Delete(conta);
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

        public async Task<ICollection<ContaGetDto>> Find(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var contaQuery = _uow.ContaRepository.GetAllReadOnly();
            var contas = await contaQuery.ToListAsync(ct);
            var response = new List<ContaGetDto>();

            foreach (var conta in contas)
            {
                response.Add(new ContaGetDto
                {
                    Id = conta.Id,
                    IdTipoConta = conta.IdTipoConta,
                    IdFrequencia = conta.IdFrequencia,
                    IdSituacaoPagamento = conta.IdSituacaoPagamento,
                    Valor = conta.Valor,
                    DataCriacao = conta.DataCriacao,
                    DataAbertura = conta.DataAbertura,
                    DataVencimento = conta.DataVencimento,
                    DataPagamento = conta.DataPagamento,
                });
            }

            return response;
        }

        public async Task<ContaGetDto> Get(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Conta conta = await _uow.ContaRepository.GetByIdAsync(id, ct);

            if (conta == null) throw new Exception("Registro não encontrado.");

            return new ContaGetDto
            {
                Id = conta.Id,
                IdTipoConta = conta.IdTipoConta,
                IdFrequencia = conta.IdFrequencia,
                IdSituacaoPagamento = conta.IdSituacaoPagamento,
                Valor = conta.Valor,
                DataCriacao = conta.DataCriacao,
                DataAbertura = conta.DataAbertura,
                DataVencimento = conta.DataVencimento,
                DataPagamento = conta.DataPagamento,
            };
        }

        public async Task<int> Update(int id, ContaPutDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            Conta conta = await _uow.ContaRepository.GetByIdAsync(id, ct);

            if (conta == null) throw new Exception("Registro não encontrado.");

            _mapper.MapearEntidade(conta, dto);

            await Validate(conta, _validator);

            await _uow.CommitAsync();

            return conta.Id;
        }
    }
}
