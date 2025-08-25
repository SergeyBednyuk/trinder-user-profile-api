using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllUserProfile;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllFullUserProfile;

public class GetAllFullUserProfileCommandHandler(ILogger<GetAllFullUserProfileCommandHandler> logger,
    IUserProfilesRepository userProfilesRepository,
    IMapper mapper) : IRequestHandler<GetAllFullUserProfileCommand, IReadOnlyCollection<ResponseTrinderFullUserProfileDto>>
{
    public async Task<IReadOnlyCollection<ResponseTrinderFullUserProfileDto>> Handle(GetAllFullUserProfileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all full user profiles");
        var allUserProfiles = await userProfilesRepository.GetAllFullAsync(cancellationToken);

        var allUserProfilesDtos = mapper.Map<IReadOnlyCollection<ResponseTrinderFullUserProfileDto>>(allUserProfiles);
        return allUserProfilesDtos;
    }
}
