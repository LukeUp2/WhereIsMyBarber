using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using WhereIsMyBarber.Communication.Requests;
using WhereIsMyBarber.Communication.Responses;
using WhereIsMyBarber.Domain.Extensions;
using WhereIsMyBarber.Domain.Repositories;
using WhereIsMyBarber.Domain.Security.Cryptography;
using WhereIsMyBarber.Exceptions.Exceptions;

namespace WhereIsMyBarber.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncrypter _passwordEncrypter;

        public DoLoginUseCase(IUserRepository userRepository, IPasswordEncrypter passwordEncrypter)
        {
            _userRepository = userRepository;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestDoLogin request)
        {
            Validate(request);

            var encryptedPasswordToCheck = _passwordEncrypter.Encrypt(request.Password);
            var user = await _userRepository.GetUserWithEmailAndHashedPassword(request.Email, encryptedPasswordToCheck) ?? throw new InvalidLoginException();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = string.Empty
                }
            };

        }

        private static void Validate(RequestDoLogin request)
        {
            var validator = new DoLoginUseCaseValidator();
            var result = validator.Validate(request);

            if (result.IsValid.IsFalse())
            {
                throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}