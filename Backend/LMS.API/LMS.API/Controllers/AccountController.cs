using LMS.Application.Dtos.AccountDtos;
using LMS.Application.Features.Services;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManagementService _userService;
        EventMessages messages = new EventMessages();
        public AccountController(IUserManagementService userService)
        {
            _userService = userService;
        }
        //[Authorize]
        [HttpPost("Create/User")]
        public async Task<IActionResult> CreateUser(UserRequestDto request)
        {
            try
            {
                var result = await _userService.CreateUserAsync(request);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("User") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous] // important — don't require a token to get a token
        public async Task<ActionResult<LoginResponseDto>> SignIn(
        [FromBody] LoginRequestDto request)
        {
            var result = await _userService.SignInAsync(request);
            return Ok(result);
        }
        //[Authorize]
        //[HttpPost("Create/Role")]
        //public async Task<IActionResult> CreateRole(UserRoleDto request)
        //{
        //    try
        //    {
        //        //var result = await _userService.CreateRoleAsync(request);
        //        return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Role") });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
        //        throw;
        //    }
        //}
    }
}
