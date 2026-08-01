using LMS.Application.Dtos.LoanDtos;
using LMS.Application.Features.Services;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        EventMessages messages = new EventMessages();
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }
        [Authorize]
        [HttpPost("Create/Loan")]
        public async Task<IActionResult> CreateLoan(LoanRequestDto request)
        {
            try
            {
                var result = await _loanService.CreateLoanAsync(request);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Loan") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
    }
}
