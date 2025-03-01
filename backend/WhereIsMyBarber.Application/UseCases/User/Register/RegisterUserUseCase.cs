using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WhereIsMyBarber.Communication.Requests;
using WhereIsMyBarber.Communication.Responses;
using WhereIsMyBarber.Domain.Entities;
using WhereIsMyBarber.Domain.Extensions;
using WhereIsMyBarber.Domain.Repositories;
using WhereIsMyBarber.Domain.Security.Cryptography;

namespace WhereIsMyBarber.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordEncrypter _passwordEncrypter;

        public RegisterUserUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IPasswordEncrypter passwordEncrypter)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUser request)
        {
            Validate(request);

            //Fazer a criptografia da senha
            var user = _mapper.Map<Domain.Entities.User>(request);
            user.HashedPassword = _passwordEncrypter.Encrypt(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            await _userRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
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
                //Criar exceptions
                throw new Exception(result.Errors.First().ErrorMessage);
            }
        }
    }
}