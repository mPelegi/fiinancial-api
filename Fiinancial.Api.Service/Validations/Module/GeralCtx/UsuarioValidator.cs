using Fiinancial.Api.Domain.Entities.GeralCtx;
using Fiinancial.Api.Service.Validations.Base;
using FluentValidation;

namespace Fiinancial.Api.Service.Validations.Module.GeralCtx
{
    public class UsuarioValidator : BaseValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Email"))
                .MaximumLength(50).WithMessage(MensagemTamanhoMaximoCampo("Email", 50))
                .EmailAddress().WithMessage(MensagemCampoInvalido("Email"));

            RuleFor(x => x.Nome)
                .NotNull().WithMessage(MensagemCampoObrigatorio("Nome"))
                .NotEmpty().WithMessage(MensagemCampoInvalido("Nome"))
                .MaximumLength(50).WithMessage(MensagemTamanhoMaximoCampo("Nome", 50));
        }
    }
}
