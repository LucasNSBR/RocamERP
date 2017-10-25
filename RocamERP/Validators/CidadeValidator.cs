using FluentValidation;

namespace RocamERP.Validators
{
    public class CidadeValidator : AbstractValidator<Models.Cidade>
    {
        public CidadeValidator()
        {
            RuleFor(c => c.CEP).NotEmpty();
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.EstadoId).NotEmpty();
        }
    }
}