﻿using FluentValidation.Results;
using System.Collections.Generic;
using Usuario.Business.Dtos;
using Usuario.Business.Entidade;
using Usuario.Business.Interfaces.Repositorio;
using Usuario.Business.Interfaces.Servico;
using Usuario.Business.Validacao;

namespace Usuario.Business.Servico
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IRepositorio _repositorio;

        public AlunoServico(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        IList<Aluno> IAlunoServico.ListarAlunos()
        {
            return _repositorio.ListarAlunos();
        }

        Retorno IAlunoServico.CadastrarAluno(Aluno aluno)
        {
            Retorno retorno = dadosAlunoValido(aluno);

            if (retorno.sucesso)
            {
                bool gravouAluno = _repositorio.CadastrarAluno(aluno);
                return new Retorno() { sucesso = gravouAluno };
            }

            return new Retorno() { sucesso = retorno.sucesso, mensagens = retorno.mensagens };
        }

        Retorno IAlunoServico.RemoverAluno(int idAluno)
        {
            Retorno retorno = idAlunoValido(idAluno);

            if (retorno.sucesso)
            {
                bool removeuAluno = _repositorio.ExcluirAluno(idAluno);
                return new Retorno() { sucesso = removeuAluno };
            }

            return new Retorno() { sucesso = retorno.sucesso, mensagens = retorno.mensagens };

        }

        Retorno IAlunoServico.AtualizarAluno(Aluno aluno)
        {
            Retorno retorno = idAlunoValido(aluno.Id);

            if (retorno.sucesso)
            {
                bool atualizouAluno = _repositorio.AtualizarAluno(aluno);
                return new Retorno() { sucesso = atualizouAluno };
            }

            return retorno;
        }

        private Retorno dadosAlunoValido(Aluno aluno)
        {
            AlunoValidator validacaoAluno = new AlunoValidator();

            ValidationResult resultadoValidacao = validacaoAluno.Validate(aluno);

            Retorno retorno = new Retorno();

            if (!resultadoValidacao.IsValid)
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    retorno.sucesso = false;
                    retorno.mensagens.Add(item.ErrorMessage);
                }
                return retorno;
            }

            retorno.sucesso = true;
            return retorno;
        }

        private Retorno idAlunoValido(int idAluno)
        {
            return VerificaId.idAlunoValido(idAluno);
        }

        public Aluno ObterAlunoPorId(int idAluno)
        {
            return _repositorio.ObterAlunoPorId(idAluno);
        }
    }
}
