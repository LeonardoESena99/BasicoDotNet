using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations
{
    public class PostAvisoRequestValidar : AbstractValidator<PostAvisoRequest>
    {
        public PostAvisoRequestValidar()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("É obrigatório informar o título.");

            RuleFor(x => x.Mensagem)
                .NotEmpty()
                .WithMessage("É obrigatório informar a mensagem.");
        }
    }
}
