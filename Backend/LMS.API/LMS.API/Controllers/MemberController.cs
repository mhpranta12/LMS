using LMS.Application.Dtos.MemberDtos;
using LMS.Application.Features.Services;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        EventMessages messages = new EventMessages();
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [Authorize]
        [HttpPost("Create/Member")]
        public async Task<IActionResult> CreateMember(MemberRequestDto request)
        {
            try
            {
                var result = await _memberService.CreateMemberAsync(request); 
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Member") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult
                {
                    Result = false,
                    IsSuccess = false,
                    Message = messages.Required
                });
                throw;
            }
        }
    }
}
