using Desafio3.Api.Fiap.API.Models;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;
using Desafio3.Api.Fiap.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio3.Api.Fiap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEnderecoServices _enderecoServices;

        public EnderecoController(IEnderecoServices enderecoServices, IEnderecoRepository enderecoRepository)
        {
            _enderecoServices = enderecoServices;
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var enderecos = await _enderecoRepository.Listar();
            return Ok(enderecos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Endereco endereco)
        {
            var resultado = await _enderecoServices.CadastrarEndereco(endereco);
            if (resultado.ErrorMessage!.Any())
                return BadRequest(resultado.ErrorMessage);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Endereco endereco)
        {
            var resultado = await _enderecoServices.AtualizarEndereco(endereco);
            if (resultado.ErrorMessage!.Any())
                return BadRequest(resultado.ErrorMessage);
            return Ok();
        }
    }
}
