using LMS.Application.Dtos.AccountDtos;
using LMS.Application.Dtos.BookDtos;
using LMS.Application.Features.Services;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        EventMessages messages = new EventMessages();
        public BookController(IBookService bookService) 
        { 
            _bookService = bookService;
        }
        //[Authorize]
        [HttpPost("Create/Book")]
        public async Task<IActionResult> CreateBook(BookRequestDto request)
        {
            try
            {
                var result = await _bookService.CreateBookAsync(request);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Book") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
    }
}
