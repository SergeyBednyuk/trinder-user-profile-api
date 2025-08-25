using FluentValidation;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.DeleteUserProfile;

public class DeleteUserProfileCommandValidation : AbstractValidator<DeleteUserProfileCommand>
{
    public DeleteUserProfileCommandValidation()
    {
        RuleFor(x => x.UserProfileId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Id cannot be zero or less.");
    }
}
