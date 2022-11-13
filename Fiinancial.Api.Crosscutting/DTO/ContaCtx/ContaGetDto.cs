namespace Fiinancial.Api.Crosscutting.DTO.ContaCtx
{
    public class ContaGetDto
    {
        public int Id { get; set; }
        public int IdTipoConta { get; set; }
        public int IdFrequencia { get; set; }
        public int IdSituacaoPagamento { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
