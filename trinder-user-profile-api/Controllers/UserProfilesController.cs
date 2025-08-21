using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetUserProfileById;

namespace trinder_user_profile_api.Controllers
{
    [ApiController]
    [Route("api/userprofile")]
    public class UserProfilesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] int id)
        {
            var result = await mediator.Send(new GetUserProfileByIdQuery(id));

            return Ok(result);
        }
    }
}
