using Modelo.Domain;

namespace Modelo.Aplication.Interface
{
    public interface IAlunoApplication
    {
        Task<Aluno> BuscarAluno(int codigo);

        Task AdicionarAluno(Aluno aluno);

        Task<Aluno> AtualizarAluno(Aluno aluno);

        Task<bool> Excluir(int codigo);
    }
}
