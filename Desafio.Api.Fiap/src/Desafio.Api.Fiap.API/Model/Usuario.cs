namespace Desafio.Api.Fiap.API.Model
{
    public class Usuario(Guid id, string nome, string login, string senha)
    {
        public Guid Id { get; } = id;
        public string Nome { get; } = nome;
        public string Login { get; } = login;
        public string Senha { get; } = senha;
    }
}
