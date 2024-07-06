using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Repositories.Interfaces;
using Desafio.Api.Fiap.API.Services.Interfaces;

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
    }
}
