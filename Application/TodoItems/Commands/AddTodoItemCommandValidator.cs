using FluentValidation;

namespace Application.Commands;

public class AddTodoItemCommandValidator : AbstractValidator<AddTodoItemCommand>
{
    public AddTodoItemCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(100);

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}