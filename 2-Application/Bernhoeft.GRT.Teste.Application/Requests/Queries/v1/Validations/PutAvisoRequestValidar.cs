using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations
{
    public class PutAvisoRequestValidar : AbstractValidator<PutAvisoRequest>
    {
        public PutAvisoRequestValidar()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id do aviso deve ser maior que zero.");

            RuleFor(x => x.Mensagem)
             .NotEmpty()
             .WithMessage("É obrigatório informar a mensagem.");
        }
    }
}
