using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllUserProfile;

public class GetAllUserProfileCommandhandler(ILogger<GetAllUserProfileCommandhandler> logger,
    IUserProfilesRepository userProfilesRepository,
    IMapper mapper) : IRequestHandler<GetAllUserProfileCommand, IReadOnlyCollection<ResponseTrinderUserProfileDto>>
{
    public async Task<IReadOnlyCollection<ResponseTrinderUserProfileDto>> Handle(GetAllUserProfileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all user profiles");
        var userProfiles = await userProfilesRepository.GetAllAsync(cancellationToken);

        var userProfilesDtos = mapper.Map<IReadOnlyCollection<ResponseTrinderUserProfileDto>>(userProfiles);
        return userProfilesDtos;
    }
}
