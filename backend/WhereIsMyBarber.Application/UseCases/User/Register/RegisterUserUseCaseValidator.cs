using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WhereIsMyBarber.Communication.Requests;

namespace WhereIsMyBarber.Application.UseCases.User.Register
{
    public class RegisterUserUseCaseValidator : AbstractValidator<RequestRegisterUser>
    {
        public RegisterUserUseCaseValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Forneça um email");
            When(u => string.IsNullOrEmpty(u.Email) == false, () =>
            {
                RuleFor(u => u.Email).EmailAddress().WithMessage("Email inválido");
            });
            RuleFor(u => u.Phone).NotEmpty().WithMessage("Forneça um telefone");
            RuleFor(u => u.Name).NotEmpty().WithMessage("Forneça um nome");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Forneça uma senha");
            When(u => string.IsNullOrEmpty(u.Password) == false, () =>
            {
                RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve conter no minimo 6 caracteres");
            });
            RuleFor(u => u.Type).IsInEnum().WithMessage("Tipo de usuário informado não é válido");
        }
    }
}