using Microsoft.Extensions.DependencyInjection;
using WhereIsMyBarber.Application.Services.AutoMapper;
using WhereIsMyBarber.Application.UseCases.User.Register;

namespace WhereIsMyBarber.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(opt => new AutoMapper.MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
    }
}