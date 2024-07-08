﻿using Dapper;
using Desafio3.Api.Fiap.API.Models;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;
using System.Data;

namespace Desafio3.Api.Fiap.API.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public FuncionarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Cadastrar(Funcionario funcionario)
        {
            var sqlCommand = "INSERT INTO \"Funcionario\" (\"Id\", \"Nome\", \"Idade\", \"Pais\") VALUES (@Id, @Nome, @Idade, @Pais)";
            _dbConnection.Execute(sqlCommand, funcionario);
        }

        public async Task<IEnumerable<Funcionario>> Listar()
        {
            var sqlCommand = "SELECT * FROM \"Funcionario\"";
            return await _dbConnection.QueryAsync<Funcionario>(sqlCommand);
        }
    }
}
