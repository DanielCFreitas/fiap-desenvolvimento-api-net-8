using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Fiap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Cadastra um novo usuario no sistema
        /// </summary>
        /// <param name="usuario">Usuario que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return Ok();
        }
    }
}
