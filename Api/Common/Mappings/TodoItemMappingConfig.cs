using Application.Commands;
using Contracts;
using Mapster;

namespace Api.Common;

public class TodoItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddTodoItemRequest, AddTodoItemCommand>();
        config.NewConfig<AddTodoItemResult, AddTodoItemResponse>()
            .Map(dest => dest, src => src.TodoItem);
    }
}