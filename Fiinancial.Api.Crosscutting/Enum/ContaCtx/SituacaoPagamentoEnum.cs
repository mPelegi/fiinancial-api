using System.ComponentModel;

namespace Fiinancial.Api.Crosscutting.Enum.ContaCtx
{
    public enum SituacaoPagamentoEnum
    {
        [Description("Pagamento Pendente")]
        Aguardando = 1,

        [Description("Pagamento Atrasado")]
        Atrasado,

        [Description("Pagamento Cancelado")]
        Cancelado,

        [Description("Pagamento Realizado")]
        Pago,

        [Description("Pagamento Realizado Atrasado")]
        PagoAtrasado,
    }
}
