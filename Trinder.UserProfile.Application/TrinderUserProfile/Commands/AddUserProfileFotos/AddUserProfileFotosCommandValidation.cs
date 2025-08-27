using FluentValidation;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommandValidation : AbstractValidator<AddUserProfileFotosCommand>
{
    public AddUserProfileFotosCommandValidation()
    {
        RuleFor(x => x.UserProfileId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("UserProfileId cannot be less tnat zero.");
    }
}
