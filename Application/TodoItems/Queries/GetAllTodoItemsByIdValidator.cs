using FluentValidation;

namespace Application.Commands;

public class GetAllTodoItemByIdValidator
    : AbstractValidator<GetAllTodoItemsByUserIdQuery>
{
    public GetAllTodoItemByIdValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}