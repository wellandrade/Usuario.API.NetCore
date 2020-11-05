using System;
using System.Collections.Generic;
using System.Linq;
using Usuario.Business.Entidade;
using Usuario.Business.Interfaces.Repositorio;
using Usuario.Infra.Contexto;

namespace Usuario.Infra.Dados
{
    public class Repositorio : IRepositorio
    {
        private readonly DbContexto _db;

        public Repositorio(DbContexto db)
        {
            _db = db;
        }

        IList<Aluno> IRepositorio.ListarAlunos()
        {
            try
            {
                return _db.Alunos.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        bool IRepositorio.CadastrarAluno(Aluno aluno)
        {
            try
            {
                _db.Add(aluno);
                _db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        bool IRepositorio.ExcluirAluno(int idAluno)
        {
            try
            {
                Aluno aluno = ObterAlunoPorId(idAluno);

                if (aluno == null)
                {
                    return false;
                }

                _db.Remove(aluno);
                _db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        bool IRepositorio.AtualizarAluno(Aluno aluno)
        {
            _db.Alunos.Update(aluno);
            _db.SaveChanges();
            return true;
        }

        public Aluno ObterAlunoPorId(int idAluno)
        {
            Aluno aluno = _db.Alunos.Where(x => x.Id == idAluno).FirstOrDefault();

            if (aluno == null)
            {
                return new Aluno();
            }

            return aluno;
        }
    }
}
