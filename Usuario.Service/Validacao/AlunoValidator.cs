﻿using FluentValidation;
using System;
using Usuario.Business.Entidade;

namespace Usuario.Business.Validacao
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.DataNascimento).LessThan(DateTime.Today).WithMessage("Data nascimento não pode ser maior que a data atual");

            RuleFor(x => x.Escolaridade).IsInEnum().WithMessage("Nível de escolaridade invalido");
        }
    }
}
