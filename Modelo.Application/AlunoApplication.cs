using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Aplication.Interface;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;

namespace Modelo.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoApplication(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task AdicionarAluno(Aluno aluno)
        {
            await _alunoRepositorio.AdicionarAluno(aluno);
        }

        public async Task<Aluno> BuscarAluno(int codigo)
        {
            return await _alunoRepositorio.BuscarAluno(codigo);
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno)
        {
            return await _alunoRepositorio.AtualizarAluno(aluno);
        }

        public async Task<bool> Excluir(int codigo)
        {
            return await _alunoRepositorio.Excluir(codigo);
        }
    }
}
