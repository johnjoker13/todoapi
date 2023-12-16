using Application.Commands;
using Contracts;
using Domain.Entities;
using Mapster;

namespace Api.Common;

public class TodoItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddTodoItemRequest, AddTodoItemCommand>();

        config.NewConfig<AddTodoItemResult, AddTodoItemResponse>()
            .Map(dest => dest, src => src.TodoItem);

        config
            .NewConfig<GetAllTodoItemsByUserIdRequest, GetAllTodoItemsByUserIdQuery>();

        config
            .NewConfig<TodoItem, GetAllTodoItemsByUserIdResponse>();
    }
}