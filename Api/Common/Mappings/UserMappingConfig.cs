using Application.Commands;
using Contracts;
using Mapster;

namespace Api.Common;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<RegisterResult, RegisterResponse>()
            .Map(dest => dest, src => src.User);

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<LoginResult, LoginResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);

        config.NewConfig<UpdateFirstNameRequest, UpdateFirstNameCommand>();
        config.NewConfig<CommonUserResult, CommonUserResponse>()
            .Map(dest => dest, src => src.User);
    }
}