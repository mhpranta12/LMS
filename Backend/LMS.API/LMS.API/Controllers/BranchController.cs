using LMS.Application.Dtos.BranchDtos;
using LMS.Application.Features.Services;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService; 
        EventMessages messages = new EventMessages(); 
        public BranchController(IBranchService branchService) 
        { 
            _branchService = branchService; 
        } 
        //[Authorize]
        [HttpPost("CreateOrUpdate/Branch")]
        public async Task<IActionResult> CreateOrUpdateBranch(BranchRequestDto request)
        { 
            try 
            { 
                var result = await _branchService.CreateOrUpdateBranchAsync(request); 
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Branch") }); }
            catch (Exception ex) 
            { 
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required }); 
                throw; 
            } 
        }
    }
}
