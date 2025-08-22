using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.CreateUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfile;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetUserProfileById;

namespace trinder_user_profile_api.Controllers
{
    [ApiController]
    [Route("api/userprofile")]
    public class UserProfilesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}", Name = nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseTrinderUserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var userProfile = await mediator.Send(new GetUserProfileByIdQuery(id), cancellationToken);

            return Ok(userProfile);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseTrinderUserProfileDto))]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileCommand createUserProfile, CancellationToken cancellationToken)
        {
            var newUserProfileId = await mediator.Send(createUserProfile, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = newUserProfileId }, new { id = newUserProfileId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileInfoCommand updateUserProfileInfo, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(updateUserProfileInfo, cancellationToken);

            return NoContent();
        }
    }
}
