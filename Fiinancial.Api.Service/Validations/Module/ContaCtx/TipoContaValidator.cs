using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Service.Validations.Base;
using FluentValidation;

namespace Fiinancial.Api.Service.Validations.Module.ContaCtx
{
    public class TipoContaValidator : BaseValidator<TipoConta>
    {
        public TipoContaValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Nome"))
                .NotEmpty().WithMessage(MensagemCampoInvalido("Nome"))
                .MaximumLength(30).WithMessage(MensagemTamanhoMaximoCampo("Nome", 30));

            RuleFor(x => x.Descricao)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Descrição"))
                .NotEmpty().WithMessage(MensagemCampoInvalido("Descrição"))
                .MaximumLength(30).WithMessage(MensagemTamanhoMaximoCampo("Descrição", 100));
        }
    }
}
