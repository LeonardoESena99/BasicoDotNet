using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations
{
    public class GetAvisoIdRequestValidar : AbstractValidator<GetAvisoIdRequest>
    {
        public GetAvisoIdRequestValidar(IAvisoRepository avisoRepository)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id do aviso deve ser maior que zero.");

            RuleFor(x => x)
           .CustomAsync(async (request, context, cancellation) =>
           {
               var original = await avisoRepository.BuscarAvisoAsync(request.Id, cancellationToken: cancellation);

               if (original == null)
               {
                   context.AddFailure("Nenhum aviso encontrado.");
                   return;
               }
           });

        }
    }
}
