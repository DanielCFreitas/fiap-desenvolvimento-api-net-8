using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Repositories.Interfaces;
using Desafio.Api.Fiap.API.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.Fiap.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Cadastrar(Produto produto)
        {
            _produtoRepository.Cadastrar(produto);
        }

        public ValidationResult Excluir(Guid produtoId)
        {
            var produto = _produtoRepository.BuscarPorId(produtoId);

            if (produto is null)
                return new ValidationResult("Produto não encontrado");

            _produtoRepository.Excluir(produto);

            return new ValidationResult(string.Empty);
        }

        public IEnumerable<Produto> Listar()
        {
            return _produtoRepository.Listar();
        }
    }
}
