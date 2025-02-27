using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyBarber.Communication.Requests;
using WhereIsMyBarber.Communication.Responses;
using WhereIsMyBarber.Domain.Extensions;

namespace WhereIsMyBarber.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUser request)
        {
            Validate(request);

            await Task.Delay(1000);
            return new ResponseRegisteredUserJson
            {
                Name = string.Empty,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = string.Empty,
                }
            };
        }

        private static void Validate(RequestRegisterUser request)
        {
            var validator = new RegisterUserUseCaseValidator();
            var result = validator.Validate(request);

            if (result.IsValid.IsFalse())
            {
                throw new Exception("Test");
            }
        }
    }
}