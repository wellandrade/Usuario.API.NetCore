using System.Collections.Generic;
using Usuario.Business.Dtos;
using Usuario.Business.Entidade;

namespace Usuario.Business.Interfaces.Servico
{
    public interface IAlunoServico
    {
        IList<Aluno> ListarAlunos();

        Retorno CadastrarAluno(Aluno aluno);

        Retorno RemoverAluno(int idAluno);

        Retorno AtualizarAluno(Aluno aluno);

        Aluno ObterAlunoPorId(int idAluno);
    }
}
