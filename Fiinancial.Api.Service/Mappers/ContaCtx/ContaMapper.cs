using Fiinancial.Api.Crosscutting.DTO.ContaCtx;
using Fiinancial.Api.Domain.Entities.ContaCtx;

namespace Fiinancial.Api.Service.Mappers.ContaCtx
{
    public class ContaMapper
    {
        public Conta MapearEntidade(ContaPostDto dto)
        {
            return new Conta
            {
                IdTipoConta = dto.IdTipoConta,
                IdFrequencia = dto.IdFrequencia,
                IdSituacaoPagamento = dto.IdSituacaoPagamento,
                Valor = dto.Valor,
                DataCriacao = dto.DataCriacao,
                DataAbertura = dto.DataAbertura,
                DataVencimento = dto.DataVencimento,
                DataPagamento = dto.DataPagamento,
            };
        }

        public void MapearEntidade(Conta entidade, ContaPutDto dto)
        {
            entidade.IdTipoConta = dto.IdTipoConta;
            entidade.IdFrequencia = dto.IdFrequencia;
            entidade.IdSituacaoPagamento = dto.IdSituacaoPagamento;
            entidade.Valor = dto.Valor;
            entidade.DataAbertura = dto.DataAbertura;
            entidade.DataVencimento = dto.DataVencimento;
            entidade.DataPagamento = dto.DataPagamento;
        }
    }
}
