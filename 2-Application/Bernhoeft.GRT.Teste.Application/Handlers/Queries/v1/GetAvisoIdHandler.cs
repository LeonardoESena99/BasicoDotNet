using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class GetAvisoIdHandler : IRequestHandler<GetAvisoIdRequest, IOperationResult<GetAvisosResponse>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();
        public GetAvisoIdHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<GetAvisosResponse>> Handle(GetAvisoIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _avisoRepository.BuscarAvisoAsync(request.Id, TrackingBehavior.NoTracking);

            if (result.Id <= 0)
                return OperationResult<GetAvisosResponse>.ReturnNoContent();

            return OperationResult<GetAvisosResponse>.ReturnOk(result);
        }
    }
}
