using FluentValidation;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.Validators;

public class CreateFotoDtoValidator : AbstractValidator<CreateFotoDto>
{
    public CreateFotoDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("The foto Name field cannot be empty.");

        RuleFor(x => x.Url)
            .NotNull()
            .NotEmpty()
            .WithMessage("The foto Name field cannot be empty.")
            .Matches("(http?:)?//?[^'\"<>]+?\\.(jpg|jpeg|gif|png)")
            .WithMessage("Incorrect picture url.");
    }
}
