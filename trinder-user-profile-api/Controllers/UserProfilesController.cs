using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileInterests;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.CreateUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.DeleteUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllFullUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetUserProfileById;
using Trinder.UserProfile.Domain.Interfaces;

namespace trinder_user_profile_api.Controllers
{
    [ApiController]
    [Route("api/userprofile")]
    public class UserProfilesController(IMediator mediator, 
        IBlobStorageService blobStorageService) : ControllerBase
    {
        [HttpGet("{id}", Name = nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseTrinderFullUserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var userProfile = await mediator.Send(new GetUserProfileByIdQuery(id), cancellationToken);

            return Ok(userProfile);
        }

        [HttpGet("full",Name = nameof(GetAllFull))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ResponseTrinderFullUserProfileDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFull(CancellationToken cancellationToken)
        {
            var fullUserProfiles = await mediator.Send(new GetAllFullUserProfileCommand(), cancellationToken);

            return Ok(fullUserProfiles);
        }

        [HttpGet(Name = nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ResponseTrinderUserProfileDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var userProfiles = await mediator.Send(new GetAllUserProfileCommand(), cancellationToken);

            return Ok(userProfiles);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseTrinderFullUserProfileDto))]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileCommand createUserProfile, CancellationToken cancellationToken)
        {
            var newUserProfileId = await mediator.Send(createUserProfile, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = newUserProfileId }, new { id = newUserProfileId });
        }

        [HttpPost("{userProfileId}/fotos")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseTrinderFullUserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddFotosToUserProfile([FromRoute] int userProfileId, ICollection<IFormFile> fotos, CancellationToken cancellationToken)
        {
            List<CreateFotoDto> fotoDtos = [];
            foreach (var foto in fotos)
            {
                var fileUrl = await blobStorageService.UploadToBlobStorage(foto.OpenReadStream(), $"{Guid.NewGuid()}_{foto.FileName}_{userProfileId}");

                fotoDtos.Add(new CreateFotoDto(foto.FileName, fileUrl, IsItProfileFoto: false));
            }
            
            var command = new AddUserProfileFotosCommand(userProfileId, fotoDtos);

            var updatedUserProfile = await mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = userProfileId }, updatedUserProfile);
        }

        [HttpPut("{userProfileId}/interests")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseTrinderFullUserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddInterestsToUserProfile([FromRoute] int userProfileId, [FromBody] UpdateUserInterestsRequest request, CancellationToken cancellationToken)
        {
            var command = new AddUserProfileInterestsCommand(userProfileId, request.InterestIds);

            var updatedUserProfile = await mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = userProfileId }, updatedUserProfile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileInfoCommand updateUserProfileInfo, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(updateUserProfileInfo, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteUserProfileCommand(id), cancellationToken);

            return NoContent();
        }
    }
}
