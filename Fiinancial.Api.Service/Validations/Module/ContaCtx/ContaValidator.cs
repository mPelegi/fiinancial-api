using Fiinancial.Api.Domain.Entities.ContaCtx;
using Fiinancial.Api.Service.Validations.Base;
using FluentValidation;

namespace Fiinancial.Api.Service.Validations.Module.ContaCtx
{
    public class ContaValidator : BaseValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.IdTipoConta)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Tipo Conta"));

            RuleFor(x => x.IdFrequencia)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Frequência"));

            RuleFor(x => x.IdSituacaoPagamento)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Situação Pagamento"));

            RuleFor(x => x.Valor)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Valor"))
                .NotEmpty().WithMessage(MensagemCampoInvalido("Valor"))
                .ScalePrecision(2, 10).WithMessage(MensagemPrecisaoDecimal("Valor", 2));

            RuleFor(x => x.DataCriacao)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Data Criação"));
        }
    }
}
