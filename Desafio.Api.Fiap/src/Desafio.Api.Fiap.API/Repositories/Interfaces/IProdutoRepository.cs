using Desafio.Api.Fiap.API.Model;

namespace Desafio.Api.Fiap.API.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Buscar produto por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Retorna produto encontrado</returns>
        Produto BuscarPorId(Guid id);

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

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="produto">Produto que deve ser excluido</param>
        void Excluir(Produto produto);
    }
}
