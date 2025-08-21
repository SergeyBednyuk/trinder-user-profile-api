using FluentValidation;
using Trinder.UserProfile.Application.Validators;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.CreateUserProfile;

public class CreateUserProfileCommandValidation: AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidation()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("The UserName field cannot be empty.");

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .WithMessage("The email field cannot be empty.");

        When(c => !string.IsNullOrEmpty(c.Bio), () =>
        {
            RuleFor(x => x.Bio).MinimumLength(10)
                .MinimumLength(10).WithMessage("Your bio must be at least 10 characters long.")
                .MaximumLength(500).WithMessage("Your bio cannot be longer than 500 characters.");
        });

        When(c => c.Fotos != null && c.Fotos.Count() > 0, () => 
        {
            RuleForEach(x => x.Fotos)
                .SetValidator(new CreateFotoDtoValidator());
        });

        When(c => c.Interests != null && c.Interests.Count() > 0, () =>
        {
            RuleForEach(x => x.Interests)
                .SetValidator(new CreateInterestDtoValidator());
        });
    }
}
