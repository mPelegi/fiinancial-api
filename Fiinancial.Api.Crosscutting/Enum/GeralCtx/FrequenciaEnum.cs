using System.ComponentModel;

namespace Fiinancial.Api.Crosscutting.Enum.GeralCtx
{
    public enum FrequenciaEnum
    {
        [Description("Única - 0 Dias")]
        Unica = 1,

        [Description("Diária - 1 Dia")]
        Diaria,

        [Description("Semanal - 7 Dias")]
        Semanal,

        [Description("Mensal - 30 Dias")]
        Mensal,

        [Description("Anual - 365 Dias")]
        Anual,
    }
}
