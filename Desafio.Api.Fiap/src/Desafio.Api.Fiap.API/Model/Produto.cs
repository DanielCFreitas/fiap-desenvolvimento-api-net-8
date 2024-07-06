namespace Desafio.Api.Fiap.API.Model
{
    public class Produto(Guid id, string nome, decimal preco)
    {
        public Guid Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public decimal Preco { get; set; } = preco;
    }
}
