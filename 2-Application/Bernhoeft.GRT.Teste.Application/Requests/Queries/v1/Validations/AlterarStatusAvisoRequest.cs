using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations
{
    public class AlterarStatusAvisoRequest : IRequest<bool>
    {
        public int Id { get; set; }

        public AlterarStatusAvisoRequest() { }

        public AlterarStatusAvisoRequest(int Id)
        {
            this.Id = Id;
        }
    }
}
