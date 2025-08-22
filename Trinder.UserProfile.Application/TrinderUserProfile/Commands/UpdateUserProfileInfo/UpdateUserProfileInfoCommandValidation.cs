using FluentValidation;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfile;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfileInfo;

public class UpdateUserProfileInfoCommandValidation : AbstractValidator<UpdateUserProfileInfoCommand>
{
    public UpdateUserProfileInfoCommandValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("the Id property should be greater than zero.");

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
    }
}
