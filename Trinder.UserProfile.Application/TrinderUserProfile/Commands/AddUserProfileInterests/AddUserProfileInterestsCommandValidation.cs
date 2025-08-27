using FluentValidation;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileInterests;

public class AddUserProfileInterestsCommandValidation : AbstractValidator<AddUserProfileInterestsCommand>
{
    private readonly IInterestsRepository _interestsRepository;

    public AddUserProfileInterestsCommandValidation(IInterestsRepository interestsRepository)
    {
        _interestsRepository = interestsRepository;

        RuleFor(x => x.UserProfileId)
            .GreaterThan(0) 
            .WithMessage("UserProfileId must be a positive number.");

        RuleFor(x => x.InterestsInts)
            .NotEmpty()
            .WithMessage("At least one interest must be selected.")
            .MustAsync(AllInterestsExist)
            .WithMessage("One or more of the selected interests do not exist.");
    }

    private async Task<bool> AllInterestsExist(ICollection<int> interestIds, CancellationToken token)
    {
        var distinctIdsCount = interestIds.Distinct().ToList();

        var result = await _interestsRepository.GetByIdsAsync(distinctIdsCount);

        return result.Count == distinctIdsCount.Count;
    }
}
