using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Api.Fiap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Rota para cadastrar um novo produto
        /// </summary>
        /// <param name="produto">Produto que deve ser cadastrado</param>
        /// <returns></returns>
        /// <response code="200">OK - Cadastrado com sucesso</response>
        /// <response code="500">Internal Server Error - Erro inesperado</response>
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            _produtoService.Cadastrar(produto);
            return Ok();
        }

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Produtos que estao cadastrados</returns>
        /// <response code="200">OK - Lista dos produtos que estão cadastrados</response>
        /// <response code="500">Internal Server Error - Erro inesperado</response>
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var produtos = _produtoService.Listar();
            return Ok(produtos);
        }

        /// <summary>
        /// Exclui um produto do banco de dados
        /// </summary>
        /// <param name="produtoId">Id do produto</param>
        /// <returns></returns>
        /// <response code="200">OK - Deletou um produto</response>
        /// <response code="500">Internal Server Error - Erro inesperado</response>
        [HttpDelete]
        [Route("{produtoId}")]
        public IActionResult Delete(Guid produtoId)
        {
            var resultado = _produtoService.Excluir(produtoId);

            if (!resultado.ErrorMessage.IsNullOrEmpty())
                return BadRequest(resultado.ErrorMessage);

            return Ok();
        }
    }
}
