using Dapper;
using Desafio3.Api.Fiap.API.Models;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;
using System.Data;

namespace Desafio3.Api.Fiap.API.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection _dbConnection;

        public EnderecoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Endereco?> BuscarEnderecoPorId(Guid enderecoId)
        {
            var sqlCommand = "SELECT * FROM \"Endereco\" WHERE \"Id\" = @Id LIMIT 1";
            return await _dbConnection.QueryFirstOrDefaultAsync<Endereco?>(sqlCommand, new { Id = enderecoId });
        }

        public async Task<Endereco?> BuscarEnderecoPorIdDeFuncionario(Guid funcionarioId)
        {
            var sqlCommand = "SELECT * FROM \"Endereco\" WHERE \"FuncionarioId\" = @Id LIMIT 1";
            return await _dbConnection.QueryFirstOrDefaultAsync<Endereco?>(sqlCommand, new { Id = funcionarioId });
        }

        public async Task Cadastrar(Endereco endereco)
        {
            var sqlCommand = "INSERT INTO \"Endereco\" (\"Id\", \"Rua\", \"Numero\", \"CEP\", \"Cidade\", \"Estado\", \"FuncionarioId\") " +
                "VALUES (@Id, @Rua, @Numero, @CEP, @Cidade, @Estado, @FuncionarioId)";
            await _dbConnection.ExecuteAsync(sqlCommand, endereco);
        }

        public async Task Atualizar(Endereco endereco)
        {
            var sqlCommand = "UPDATE \"Endereco\" SET \"Rua\" = @Rua, \"Numero\" = @Numero, \"CEP\" = @CEP, \"Cidade\" = @Cidade, \"Estado\" = @Estado WHERE \"Id\" = @Id";
            await _dbConnection.ExecuteAsync(sqlCommand, endereco);
        }

        public async Task<IEnumerable<Endereco>> Listar()
        {
            var sqlCommand = "SELECT * FROM \"Endereco\"";
            return await _dbConnection.QueryAsync<Endereco>(sqlCommand);
        }
    }
}
