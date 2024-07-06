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
