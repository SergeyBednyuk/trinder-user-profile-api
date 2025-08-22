using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetUserProfileById;

public class GetUserProfileByIdQueryHandler(ILogger<GetUserProfileByIdQueryHandler> logger,
    IUserProfilesRepository userProfilesRepository, IMapper mapper) : IRequestHandler<GetUserProfileByIdQuery, ResponseTrinderUserProfileDto>
{
    public async Task<ResponseTrinderUserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting {dto} by Id", nameof(ResponseTrinderUserProfileDto));

        var userProfile = await userProfilesRepository.GetByIdAsync(request.UserProfileId, cancellationToken);
        if (userProfile is null)
            throw new NotFoundException(nameof(TrinderUserProfile), request.UserProfileId.ToString());

        var userProfileDto = mapper.Map<ResponseTrinderUserProfileDto>(userProfile);

        return userProfileDto;
    }
}
