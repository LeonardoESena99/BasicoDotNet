using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1
{
    public class PostAvisoRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }

        public PostAvisoRequest() { }

        public PostAvisoRequest(PostAvisoRequest postAvisosRequest)
        {
            this.Id = postAvisosRequest.Id;
            this.Ativo = postAvisosRequest.Ativo;
            this.Titulo = postAvisosRequest.Titulo;
            this.Mensagem = postAvisosRequest.Mensagem;
        }
    }
}
