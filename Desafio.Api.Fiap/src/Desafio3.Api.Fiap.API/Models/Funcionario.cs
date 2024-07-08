namespace Desafio3.Api.Fiap.API.Models
{
    public class Funcionario
    {
        public Funcionario(Guid id, string nome, int idade, string? pais)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Pais = pais;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string? Pais { get; private set; }
    }
}
