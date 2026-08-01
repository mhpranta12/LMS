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
        private readonly ILogger<BookController> _logger;

        EventMessages messages = new EventMessages();
        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        [Authorize]
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdateBook(BookRequestDto request)
        {
            try
            {
                var result = await _bookService.CreateOrUpdateBookAsync(request);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Book") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var result = await _bookService.GetBookByIdAsync(id);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Book") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var result = await _bookService.GetAllBooksAsync();
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Message("Books retrieved") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [Authorize]
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteBookById(Guid id)
        {
            try
            {
                var result = _bookService.DeleteBookAsync(id);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Delete("Book") });
            }
            catch (Exception ex)
            {

                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [Authorize]
        [HttpGet("Get/ByBranchId/{id}")]
        public async Task<IActionResult> GetAllBooksByBranchId(Guid id)
        {
            try
            {
                var result = await _bookService.GetAllBookByBranchIdAsync(id);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Book") });
            }
            catch (Exception ex)
            {

                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [Authorize]
        [HttpGet("Get/ByCategoryId/{id}")]
        public async Task<IActionResult> GetAllBooksByCategoryId(Guid id)
        {
            try
            {
                var result = await _bookService.GetAllBookByCategoryIdAsync(id);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Book") });
            }
            catch (Exception ex)
            {

                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
        [HttpGet("export/pdf")]
        public async Task<IActionResult> ExportBooksPdf()
        {
            var pdfBytes = await _bookService.GenerateBooksReportInPDFAsync();
            return File(pdfBytes, "application/pdf", $"books-report-{DateTime.UtcNow:yyyyMMdd}.pdf");
        }
    }
}
