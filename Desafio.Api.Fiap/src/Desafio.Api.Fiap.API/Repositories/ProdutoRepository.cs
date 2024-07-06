using Dapper;
using Desafio.Api.Fiap.API.Model;
using Desafio.Api.Fiap.API.Repositories.Interfaces;
using System.Data;

namespace Desafio.Api.Fiap.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProdutoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Cadastrar(Produto produto)
        {
            var sqlCommand = "INSERT INTO \"Produtos\" (\"Id\", \"Nome\", \"Preco\") VALUES" +
                " (@Id, @Nome, @Preco);";

            _dbConnection.Execute(sqlCommand, produto);
        }
    }
}
