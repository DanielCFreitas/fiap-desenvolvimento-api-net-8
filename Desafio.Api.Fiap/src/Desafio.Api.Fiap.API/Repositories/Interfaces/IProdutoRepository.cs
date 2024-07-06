using Desafio.Api.Fiap.API.Model;

namespace Desafio.Api.Fiap.API.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Cadastra um novo produto no banco de dados
        /// </summary>
        /// <param name="produto">Produto que sera cadastrado</param>
        void Cadastrar(Produto produto);

        /// <summary>
        /// Lista os produtos que estão salvos no banco de dados
        /// </summary>
        /// <returns>Lista de produtos</returns>
        IEnumerable<Produto> Listar();
    }
}
