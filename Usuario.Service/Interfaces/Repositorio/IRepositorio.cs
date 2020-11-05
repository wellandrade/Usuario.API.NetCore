using System.Collections.Generic;
using Usuario.Business.Entidade;

namespace Usuario.Business.Interfaces.Repositorio
{
    public interface IRepositorio
    {
        IList<Aluno> ListarAlunos();

        bool CadastrarAluno(Aluno aluno);

        bool ExcluirAluno(int idAluno);

        bool AtualizarAluno(Aluno aluno);

        Aluno ObterAlunoPorId(int idAluno);
    }
}
