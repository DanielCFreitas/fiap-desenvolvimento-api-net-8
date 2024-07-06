using Desafio.Api.Fiap.API.Model;

namespace Desafio.Api.Fiap.API.Services.Interfaces
{
    public interface IProdutoService
    {
        /// <summary>
        /// Cadastrar produto no banco de dados
        /// </summary>
        /// <param name="produto">Produto que deve ser cadastrado</param>
        void Cadastrar(Produto produto);

        /// <summary>
        /// Lista os produtos que estão cadastrados
        /// </summary>
        /// <returns>Produtos que estão cadatrados</returns>
        IEnumerable<Produto> Listar();
    }
}
