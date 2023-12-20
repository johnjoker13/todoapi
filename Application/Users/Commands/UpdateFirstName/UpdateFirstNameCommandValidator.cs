using FluentValidation;

namespace Application.Commands;

public class UpdateFirstNameCommandValidator
    : AbstractValidator<UpdateFirstNameCommand>
{
    public UpdateFirstNameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.FirstName)
            .NotEmpty();
    }
}