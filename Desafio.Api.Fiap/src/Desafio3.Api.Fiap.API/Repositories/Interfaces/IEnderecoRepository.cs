using Desafio3.Api.Fiap.API.Models;

namespace Desafio3.Api.Fiap.API.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco?> BuscarEnderecoPorId(Guid enderecoId);
        Task<Endereco?> BuscarEnderecoPorIdDeFuncionario(Guid funcionarioId);
        Task Cadastrar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task<IEnumerable<Endereco>> Listar();
    }
}
