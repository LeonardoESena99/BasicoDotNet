using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1
{
    public class PutAvisoRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }

        public PutAvisoRequest() { }
    }
}
