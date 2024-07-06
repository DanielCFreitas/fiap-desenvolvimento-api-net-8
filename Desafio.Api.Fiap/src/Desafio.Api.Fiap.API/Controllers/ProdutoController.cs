using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            _produtoService.Cadastrar(produto);
            return Ok();
        }
    }
}
