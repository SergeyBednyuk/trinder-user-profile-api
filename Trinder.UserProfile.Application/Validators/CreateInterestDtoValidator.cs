using FluentValidation;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.Validators;

public class CreateInterestDtoValidator : AbstractValidator<CreateInterestDto>
{
    public CreateInterestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotEmpty()
            .WithMessage("The interest name field cannot be empty.");
    }
}
