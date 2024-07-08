using Desafio3.Api.Fiap.API.Models;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;
using Desafio3.Api.Fiap.API.Services.Interfaces;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace Desafio3.Api.Fiap.API.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        private readonly IMongoCollection<FuncionarioLocalizacoes> _collectionFuncionarioLocalizacoes;

        public EnderecoServices(IEnderecoRepository enderecoRepository, IFuncionarioRepository funcionarioRepository, IMongoClient mongoClient)
        {
            _enderecoRepository = enderecoRepository;
            _funcionarioRepository = funcionarioRepository;

            _collectionFuncionarioLocalizacoes = mongoClient
                .GetDatabase("Desafio3FIAP")
                .GetCollection<FuncionarioLocalizacoes>("FuncionarioLocalizacoes");
        }

        public async Task<ValidationResult> AtualizarEndereco(Endereco enderecoNovo)
        {
            var funcionario = await _funcionarioRepository.BuscarFuncinarioPorId(enderecoNovo.FuncionarioId);

            if (funcionario is null)
                return new ValidationResult("Funcionário não encontrado");

            var endereco = await _enderecoRepository.BuscarEnderecoPorId(enderecoNovo.Id);

            if (endereco is null)
                return new ValidationResult("Endereço não encontrado");

            var funcionarioLocalizacoes = new FuncionarioLocalizacoes(
                funcionario.Id,
                $"Rua: {endereco.Rua}, {endereco.Numero} ({endereco.CEP})",
                $"Rua: {enderecoNovo.Rua}, {enderecoNovo.Numero} ({enderecoNovo.CEP})");

            endereco.AtualizarEndereco(enderecoNovo.Rua, enderecoNovo.Numero, enderecoNovo.CEP, enderecoNovo.Cidade, enderecoNovo.Estado);

            await _enderecoRepository.Atualizar(endereco);
            await _collectionFuncionarioLocalizacoes.InsertOneAsync(funcionarioLocalizacoes);

            return new ValidationResult(string.Empty);
        }

        public async Task<ValidationResult> CadastrarEndereco(Endereco endereco)
        {
            var funcionario = await _funcionarioRepository.BuscarFuncinarioPorId(endereco.FuncionarioId);

            if (funcionario is null)
                return new ValidationResult("Funcionário não encontrado");

            var enderecoCadastrado = await _enderecoRepository.BuscarEnderecoPorId(endereco.Id);

            if (enderecoCadastrado is not null)
                return new ValidationResult("Um endereço com este Id já está cadastrado, é necessário fazer uma atualização");

            await _enderecoRepository.Cadastrar(endereco);

            var enderecoNovo = $"Rua: {endereco.Rua}, {endereco.Numero} ({endereco.CEP})";
            var funcionarioLocalizacoes = new FuncionarioLocalizacoes(funcionario.Id, "Sem informação", enderecoNovo);
            await _collectionFuncionarioLocalizacoes.InsertOneAsync(funcionarioLocalizacoes);

            return new ValidationResult(string.Empty);
        }
    }
}
