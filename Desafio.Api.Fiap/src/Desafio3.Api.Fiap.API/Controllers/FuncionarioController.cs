using Desafio3.Api.Fiap.API.Models;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio3.Api.Fiap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var funcionarios = await _funcionarioRepository.Listar();
            return Ok(funcionarios);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            _funcionarioRepository.Cadastrar(funcionario);
            return Ok();
        }
    }
}
