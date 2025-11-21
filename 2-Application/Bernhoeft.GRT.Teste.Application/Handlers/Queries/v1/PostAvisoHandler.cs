using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class PostAvisoHandler : IRequestHandler<PostAvisoRequest, bool>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();
        public PostAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<bool> Handle(PostAvisoRequest request, CancellationToken cancellationToken)
        {
            var objeto = new AvisoEntity(id: request.Id,
                                         titulo: request.Titulo,
                                         mensagem: request.Mensagem,
                                         ativo: request.Ativo);

            return objeto.Id > 0 ? _avisoRepository.EditarAvisoAsync(objeto) : _avisoRepository.CadastrarAvisoAsync(objeto);
        }
    }
}
