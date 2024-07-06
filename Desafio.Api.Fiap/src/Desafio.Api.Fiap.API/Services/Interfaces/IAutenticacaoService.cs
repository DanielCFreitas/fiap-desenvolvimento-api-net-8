namespace Desafio.Api.Fiap.API.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        /// <summary>
        /// Recupera token de acesso através do login e senha
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o token de acesso do usuário</returns>
        Task<string> RecuperarTokenDeAcesso(string login, string senha);
    }
}
