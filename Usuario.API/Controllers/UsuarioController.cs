using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Usuario.Business.Dtos;
using Usuario.Business.Entidade;
using Usuario.Business.Interfaces.Servico;

namespace Usuario.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("v1/cadastrarAluno")]
        public ActionResult<Retorno> Post([FromServices] IAlunoServico alunoServico, [FromBody] Aluno aluno)
        {
            Retorno gravouAluno;

            try
            {
                gravouAluno = alunoServico.CadastrarAluno(aluno);

                return Ok(gravouAluno);
            }
            catch
            {
                return BadRequest("Falha ao cadastrar o aluno");
            }
        }

        [HttpGet]
        [Route("v1/listarAlunos")]
        public ActionResult<IList<Aluno>> GetAll([FromServices] IAlunoServico alunoServico)
        {
            try
            {
                return Ok(alunoServico.ListarAlunos());
            }
            catch 
            {
                return BadRequest("Falha ao obter todos os alunos");
            }
        }

        [HttpGet]
        [Route("v1/obterAlunoPorId")]
        public ActionResult<Aluno> GetById([FromServices] IAlunoServico alunoServico, int idAluno)
        {
            try
            {
                return Ok(alunoServico.ObterAlunoPorId(idAluno));
            }
            catch 
            {
                return BadRequest("Falha ao obter o aluno por id");
            }
        }

        [HttpDelete]
        [Route("v1/excluirAluno")]
        public ActionResult<Retorno> Delete([FromServices] IAlunoServico alunoServico, int idAluno)
        {
            try
            {
                Retorno removeuAluno = alunoServico.RemoverAluno(idAluno);

                return Ok(removeuAluno);
            }
            catch 
            {
                return BadRequest("Falha ao remover o aluno");
            }
        }

        [HttpPut]
        [Route("v1/alterarAluno")]
        public ActionResult<Retorno> AtualizarAluno([FromServices] IAlunoServico alunoServico, [FromBody] Aluno aluno)
        {
            try
            {
                Retorno atualizouAluno = alunoServico.AtualizarAluno(aluno);

                return Ok(atualizouAluno);
            }
            catch 
            {
                return BadRequest("Falha ao alterar os dados do aluno");
            }
        }
    }
}