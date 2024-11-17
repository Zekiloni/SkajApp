using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using SkajApp.Application.UseCases;

namespace Server.Adapters.Inbound
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserCreate _userCreate;

        public UserController(UserCreate userCreate)
        {
            _userCreate = userCreate;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser(CreateUserReq request)
        {
            UserResponse? response = await _userCreate.Handle(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserResponse>> RetrieveUser(string userId)
        {
           //UserResponse? response = await _userCreate.Handle(request);
            return Ok();
        }
    }
}
