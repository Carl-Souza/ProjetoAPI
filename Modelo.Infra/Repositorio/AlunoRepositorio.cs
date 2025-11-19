using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;
using Dapper;

namespace Modelo.Infra.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        DbConnectionFactory _dbConnectionFactory;

        public AlunoRepositorio(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<Aluno> BuscarAluno(int codigo)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "SELECT * FROM Aluno WHERE codigo = @codigo;";

            var aluno = await connnection.QueryFirstOrDefaultAsync<Aluno>(sql, new { codigo = codigo });

            return aluno;
        }

        public async Task AdicionarAluno(Aluno aluno)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "INSERT INSERT Aluno (Matricula, Nome, CEP, Logradouro, Cidade, Bairro) VALUES (@Matricula, @Nome, @CEP, @Logradouro, @Cidade, @Bairro); SELECT SCOPE_IDENTITY();";

            int codigo = await connnection.QueryFirstOrDefaultAsync<int>(sql, aluno);
            aluno.Codigo = codigo;
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "Update Aluno set Matricula = @Matricula, Nome = @Nome, CEP = @CEP, Logradouro = @Logradouro, Cidade = @Cidade, Bairro = @Bairro WHERE codigo = @codigo; SELECT * FROM Aluno WHERE codigo = @codigo;";

            Aluno aluno1 = await connnection.QueryFirstOrDefaultAsync<Aluno>(sql, aluno);
            return aluno1;
        }

        public async Task<bool> Excluir(int codigo)
        {
            using var connnection = _dbConnectionFactory.CreateConnection();

            string sql = "DELETE FROM Aluno WHERE codigo = @codigo;";

            var ret = await connnection.ExecuteAsync(sql, new { codigo });
            return ret != 0;
        }
    }
}
