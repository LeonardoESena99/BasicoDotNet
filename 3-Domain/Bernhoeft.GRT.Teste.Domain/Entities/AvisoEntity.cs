namespace Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities
{
    public partial class AvisoEntity
    {
        public int Id { get; private set; }
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }

        public AvisoEntity() { }

        public AvisoEntity(int id, string titulo, string mensagem, bool ativo)
        {
            Id = id;
            Titulo = titulo;
            Mensagem = mensagem;
            Ativo = ativo;

            if (Id > 0)
                DataModificacao = DateTime.Now;
            else
                DataCriacao = DataModificacao = DateTime.Now;
        }
    }
}