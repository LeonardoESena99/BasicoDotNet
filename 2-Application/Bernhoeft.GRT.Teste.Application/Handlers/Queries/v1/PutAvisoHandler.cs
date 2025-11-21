using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class PutAvisoHandler : IRequestHandler<PutAvisoRequest, bool>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();
        public PutAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<bool> Handle(PutAvisoRequest request, CancellationToken cancellationToken)
        {
            var objeto = new AvisoEntity(id: request.Id,
                                         titulo: "",
                                         mensagem: request.Mensagem,
                                         ativo: true);

            return _avisoRepository.EditarAvisoAsync(objeto);
        }
    }
}
