using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Utils;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.CreateUserProfile;

internal class CreateUserProfileCommandHandler(ILogger<CreateUserProfileCommandHandler> logger,
    IMapper mapper,
    IUserProfilesRepository userProfilesRepository) : IRequestHandler<CreateUserProfileCommand, int>
{
    public async Task<int> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating user profile for UserName: {UserName}, Email: {Email}",
                                request.UserName, request.Email);

        var user = await userProfilesRepository.GetByUserNameAsync(request.UserName, cancellationToken);
        if (user is not null) throw new AlreadyExistException(nameof(TrinderFullUserProfileProfile), request.UserName);

        user = await userProfilesRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is not null) throw new AlreadyExistException(nameof(TrinderFullUserProfileProfile), request.Email);

        var userProfile = new Domain.Entities.TrinderUserProfile()
        {
            UserEmail = request.Email,
            UserName = request.UserName,
            Bio = request.Bio,
            Fotos = mapper.Map<ICollection<Foto>>(request.Fotos),
            Interests = mapper.Map<ICollection<Interest>>(request.Interests)
        };

        try
        {
            var result = await userProfilesRepository.AddAsync(userProfile, cancellationToken);
            return result.Id;
        }
        //Possible database concurrency exception handler
        catch (DbUpdateConcurrencyException ex)
        {
            throw new NotSupportedException("Concurrency conflicts for " + ex.Entries.First().Metadata.Name);
        }
    }
}
