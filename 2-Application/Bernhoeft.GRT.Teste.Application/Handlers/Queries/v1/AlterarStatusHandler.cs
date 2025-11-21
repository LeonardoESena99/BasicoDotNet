using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class AlterarStatusHandler : IRequestHandler<AlterarStatusAvisoRequest, bool>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();
        public AlterarStatusHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<bool> Handle(AlterarStatusAvisoRequest request, CancellationToken cancellationToken)
        {
            return _avisoRepository.AlterarStatusAvisoAsync(request.Id);
        }
    }
}
