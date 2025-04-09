using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API.DTO.User;
using FluentValidation;

namespace API.Validation.User
{
    public class UserUpdateValidation : AbstractValidator<UpdateUserDTO>
    {
        private bool CampoPreenchido(string? valor) => !string.IsNullOrWhiteSpace(valor);
        
        public UserUpdateValidation()
        {
            RuleFor(x => x.Nome)
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres")
                .When(x => CampoPreenchido(x.Nome));


            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Formato de email inválido")
                .When(x => CampoPreenchido(x.Nome));

            RuleFor(x => x.Senha)
                .Length(6, 10).WithMessage("A senha deve ter entre 6 e 10 caracteres")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial")
                .When(x => CampoPreenchido(x.Nome));
        }
    }
}