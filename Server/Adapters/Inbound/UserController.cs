using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Server.Application.UseCases;

namespace Server.Adapters.Inbound
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserCreate _userCreate;
        private readonly UserAuth _userAuth;
        private readonly UserRetrieve _userRetrieve;

        public UserController(UserCreate userCreate, UserAuth userAuth, UserRetrieve userRetrieve)
        {
            _userCreate = userCreate;
            _userAuth = userAuth;
            _userRetrieve = userRetrieve;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser(CreateUserRequest request)
        {
            UserResponse? response = await _userCreate.Handle(request);
            return Ok(response);
        }

        [HttpPost("auth")]
        public async Task<ActionResult<UserAuthResponse>> AuthUser(UserAuthRequest request)
        {
            UserAuthResponse? response = await _userAuth.Handle(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponse>> RetrieveUser(string userId)
        {
            UserResponse? response = await _userRetrieve.Handle(userId);
            return Ok(response);
        }
    }
}
