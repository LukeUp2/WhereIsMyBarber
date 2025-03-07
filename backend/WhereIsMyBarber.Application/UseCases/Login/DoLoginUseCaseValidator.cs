using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WhereIsMyBarber.Communication.Requests;
using WhereIsMyBarber.Domain.Extensions;

namespace WhereIsMyBarber.Application.UseCases.Login
{
    public class DoLoginUseCaseValidator : AbstractValidator<RequestDoLogin>
    {
        public DoLoginUseCaseValidator()
        {
            RuleFor(request => request.Email).NotEmpty().WithMessage("Por favor, forneça um email");
            When(request => string.IsNullOrEmpty(request.Email).IsFalse(), () =>
            {
                RuleFor(request => request.Email).EmailAddress().WithMessage("Email inválido");
            });
            RuleFor(request => request.Password).NotEmpty().WithMessage("Por favor, forneça uma senha");
        }
    }
}