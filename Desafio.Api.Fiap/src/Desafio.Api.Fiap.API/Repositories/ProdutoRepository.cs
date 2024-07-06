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

        public Produto BuscarPorId(Guid id)
        {
            var sqlCommand = "SELECT * FROM \"Produtos\" WHERE \"Id\" = @Id LIMIT 1";

            return _dbConnection.QueryFirst<Produto>(sqlCommand, new { Id = id });
        }

        public void Cadastrar(Produto produto)
        {
            var sqlCommand = "INSERT INTO \"Produtos\" (\"Id\", \"Nome\", \"Preco\") VALUES" +
                " (@Id, @Nome, @Preco);";

            _dbConnection.Execute(sqlCommand, produto);
        }

        public IEnumerable<Produto> Listar()
        {
            var sqlCommand = "SELECT * FROM \"Produtos\"";

            return _dbConnection.Query<Produto>(sqlCommand);
        }

        public void Excluir(Produto produto)
        {
            var sqlCommand = "DELETE FROM \"Produtos\" WHERE \"Id\" = @Id";

            _dbConnection.Execute(sqlCommand, new { Id = produto.Id });
        }
    }
}
