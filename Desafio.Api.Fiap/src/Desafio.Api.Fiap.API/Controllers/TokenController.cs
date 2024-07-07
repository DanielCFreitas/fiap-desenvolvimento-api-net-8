using Desafio.Api.Fiap.API.Services.Interfaces;
using Desafio.Api.Fiap.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Api.Fiap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;
         
        public TokenController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        /// <summary>
        /// Rota para realizar autenticacao de usuario
        /// </summary>
        /// <param name="autenticacao">Dados que devem ser recebidos para autenticar o usuario</param>
        /// <returns></returns>
        /// <response code="200">OK - Token recuperado com sucesso</response>
        /// <response code="400">BadRequest - Não conseguiur recuperar o token</response>
        /// <response code="500">Internal Server Error - Erro inesperado</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AutenticacaoDoUsuarioViewModel autenticacao)
        {
            var token = await _autenticacaoService.RecuperarTokenDeAcesso(autenticacao.Usuario, autenticacao.Senha);

            if (token.IsNullOrEmpty())
                return BadRequest("Autenticação não realizada");
            return Ok(token);
        }
    }
}
