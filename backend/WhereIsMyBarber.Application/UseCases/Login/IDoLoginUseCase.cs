using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyBarber.Communication.Requests;
using WhereIsMyBarber.Communication.Responses;

namespace WhereIsMyBarber.Application.UseCases.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestDoLogin request);
    }
}