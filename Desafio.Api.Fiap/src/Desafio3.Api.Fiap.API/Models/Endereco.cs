namespace Desafio3.Api.Fiap.API.Models
{
    public class Endereco
    {
        public Endereco(Guid id, string rua, int numero, string cEP, string cidade, string estado, Guid funcionarioId)
        {
            Id = id;
            Rua = rua;
            Numero = numero;
            CEP = cEP;
            Cidade = cidade;
            Estado = estado;
            FuncionarioId = funcionarioId;
        }

        public Guid Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}
