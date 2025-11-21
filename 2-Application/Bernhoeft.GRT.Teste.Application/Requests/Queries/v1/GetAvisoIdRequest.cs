using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1
{
    public class GetAvisoIdRequest : IRequest<IOperationResult<GetAvisosResponse>>
    {
        public int Id { get; set; }

        public GetAvisoIdRequest(int Id)
        {
            this.Id = Id;
        }
    }
}
