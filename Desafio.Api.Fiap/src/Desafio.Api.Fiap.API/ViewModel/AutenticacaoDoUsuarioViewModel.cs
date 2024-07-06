using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.Fiap.API.ViewModel
{
    /// <summary>
    /// View model usada para realizar autenticacao de um cliente
    /// </summary>
    public record AutenticacaoDoUsuarioViewModel
    {
        [Required(ErrorMessage = "O {0} precisa ser informado")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "A {0} precisa ser informada")]
        public string Senha { get; set; }
    }
}
