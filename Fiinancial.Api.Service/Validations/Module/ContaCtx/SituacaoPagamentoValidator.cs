using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Service.Validations.Base;
using FluentValidation;

namespace Fiinancial.Api.Service.Validations.Module.ContaCtx
{
    public class SituacaoPagamentoValidator : BaseValidator<SituacaoPagamento>
    {
        public SituacaoPagamentoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Nome"))
                .NotEmpty().WithMessage(MensagemCampoInvalido("Nome"))
                .MaximumLength(30).WithMessage(MensagemTamanhoMaximoCampo("Nome", 30));
        }
    }
}
