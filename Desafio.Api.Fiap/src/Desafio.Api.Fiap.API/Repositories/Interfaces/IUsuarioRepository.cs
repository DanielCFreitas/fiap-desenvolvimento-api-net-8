using Desafio.Api.Fiap.API.Model;

namespace Desafio.Api.Fiap.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra novo usuario no banco de dados
        /// </summary>
        /// <param name="usuario">Usuario para ser cadastrado</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Busca um usuario por login e senha
        /// </summary>
        /// <param name="login">Login do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>Usuario que foi encontrado</returns>
        Task<Usuario?> BuscarUsuarioPorLoginESenha(string login, string senha);
    }
}
