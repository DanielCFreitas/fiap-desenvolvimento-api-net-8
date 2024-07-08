using Desafio3.Api.Fiap.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Desafio3.Api.Fiap.API.Services.Interfaces
{
    public interface IEnderecoServices
    {
        Task<ValidationResult> CadastrarEndereco(Endereco endereco);
        Task<ValidationResult> AtualizarEndereco(Endereco enderecoNovo);
    }
}
