using FluentValidation;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommandValidation : AbstractValidator<AddUserProfileFotosCommand>
{
    public AddUserProfileFotosCommandValidation()
    {
        RuleForEach(x => x.Fotos)
            .Must(x => x.Length > 500000000)
            .WithMessage("Foto should be less tnat 500mb");
    }
}
