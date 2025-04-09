using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using FluentValidation;

namespace API.Validation.User
{
    public class UserCreateValidation : AbstractValidator<CreateUserDTO>
    {
        public UserCreateValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("Formato de email inválido");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória")
                .Length(6, 10).WithMessage("A senha deve ter entre 6 e 10 caracteres")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial");
        }
    }
}