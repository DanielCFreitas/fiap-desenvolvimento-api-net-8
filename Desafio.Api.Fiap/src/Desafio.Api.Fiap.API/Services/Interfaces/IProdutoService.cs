using Desafio.Api.Fiap.API.Model;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Exclui um produto pelo seu Id
        /// </summary>
        /// <param name="produtoId">Id do produto</param>
        ValidationResult Excluir(Guid produtoId);
    }
}
