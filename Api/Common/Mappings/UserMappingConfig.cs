using Application.Commands;
using Contracts;
using Mapster;

namespace Api.Common;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<LoginResult, LoginResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}