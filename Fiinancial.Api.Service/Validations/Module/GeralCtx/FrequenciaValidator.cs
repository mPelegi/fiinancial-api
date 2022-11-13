using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Service.Validations.Base;
using FluentValidation;

namespace Fiinancial.Api.Service.Validations.Module.GeralCtx
{
    public class FrequenciaValidator : BaseValidator<Frequencia>
    {
        public FrequenciaValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Nome"))
                .NotEmpty().WithMessage(MensagemCampoInvalido("Nome"))
                .MaximumLength(30).WithMessage(MensagemTamanhoMaximoCampo("Nome", 30));

            RuleFor(x => x.IntervaloDias)
                .GreaterThanOrEqualTo(0).WithMessage(MensagemValorPositivo("Intervalo Dias"));
        }
    }
}
