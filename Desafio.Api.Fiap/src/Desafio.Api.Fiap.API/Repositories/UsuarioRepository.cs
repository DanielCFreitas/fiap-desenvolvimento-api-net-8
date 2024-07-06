using Dapper;
using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Repositories.Interfaces;
using System.Data;

namespace Desafio.Api.Fiap.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Cadastrar(Usuario usuario)
        {
            var sqlCommand = $"INSERT INTO \"Usuarios\" (\"Id\", \"Nome\", \"Login\", \"Senha\") " +
                $"VALUES (@Id, @Nome, @Login, @Senha)";

            _dbConnection.Execute(sqlCommand, usuario);
        }

        public async Task<Usuario?> BuscarUsuarioPorLoginESenha(string login, string senha)
        {
            var sqlCommand = "SELECT * FROM \"Usuarios\" WHERE \"Login\" = @Login AND \"Senha\" = @Senha";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sqlCommand,
                new { Login = login, Senha = senha }
            );
        }
    }
}
