using Application.Commands;
using Contracts;
using Mapster;

namespace Api.Common;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}