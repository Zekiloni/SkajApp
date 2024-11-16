using Microsoft.AspNetCore.Mvc;
using SkajApp.ApiService.Application.DTOs;
using SkajApp.ApiService.Application.UseCases;

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
        public async Task<ActionResult<UserResponse>> CreateUser(CreateUserRequest request)
        {
            UserResponse? response = await _userCreate.Handle(request);
            return Ok(response);
        }
    }
}
