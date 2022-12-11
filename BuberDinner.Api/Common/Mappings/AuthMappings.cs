using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts;
using Mapster;

namespace BuberDinner.Api.Common.Mappings
{
    public class AuthMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>()
                .Map(dest => dest.Email, src => src.email)
                .Map(dest => dest.FirstName, src => src.firstName)
                .Map(dest => dest.LastName, src => src.lastName)
                .Map(dest => dest.Password, src => src.password);

            config.NewConfig<LoginRequest, LoginQuery>()
                .Map(dest => dest.Email, src => src.email)
                .Map(dest => dest.Password, src => src.password);

            config.NewConfig<AuthenticationResult, AuthResponse>()
                .Map(dest => dest.id, src => src.Id)
                .Map(dest => dest.firstName, src => src.FirstName)
                .Map(dest => dest.lastName, src => src.LastName)
                .Map(dest => dest.email, src => src.Email)
                .Map(dest => dest.token, src => src.Token);
        }
    }
}
