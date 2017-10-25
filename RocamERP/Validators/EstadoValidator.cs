using FluentValidation;

namespace RocamERP.Validators
{
    [FluentValidation.Attributes.Validator(typeof(Models.Estado))]
    public class EstadoValidator : AbstractValidator<Models.Estado>
    {
        public EstadoValidator()
        {
            RuleFor(e => e.Nome).NotEmpty()
                .MaximumLength(20)
                .WithMessage("O estado não pode estar em branco");
        }
    }
}