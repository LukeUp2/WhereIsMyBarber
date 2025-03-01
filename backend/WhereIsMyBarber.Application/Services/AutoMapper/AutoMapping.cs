using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WhereIsMyBarber.Communication.Requests;
using WhereIsMyBarber.Domain.Entities;

namespace WhereIsMyBarber.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUser, User>()
                .ForMember(dest => dest.HashedPassword, opt => opt.Ignore())
                .ForMember(dest => dest.UserIdentifier, opt => opt.Ignore());
        }

        private void DomainToResponse()
        {

        }
    }
}