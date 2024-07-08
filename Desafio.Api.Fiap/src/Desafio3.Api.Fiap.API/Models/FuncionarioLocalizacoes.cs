using MongoDB.Bson;

namespace Desafio3.Api.Fiap.API.Models
{
    public class FuncionarioLocalizacoes
    {
        public FuncionarioLocalizacoes(Guid funcionarioId, string enderecoAntigo, string enderecoNovo)
        {
            FuncionarioId = funcionarioId;
            EnderecoAntigo = enderecoAntigo;
            EnderecoNovo = enderecoNovo;
        }

        public ObjectId Id { get; private set; }
        public Guid FuncionarioId { get; private set; }
        public string EnderecoAntigo { get; private set; }
        public string EnderecoNovo { get; private set; }
    }
}
