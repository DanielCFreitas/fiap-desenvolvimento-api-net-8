using Desafio3.Api.Fiap.API.Models;

namespace Desafio3.Api.Fiap.API.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Cadastrar(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> Listar();
    }
}
