using LMS.Application.Dtos.CategoryDtos;
using LMS.Application.Features.Services;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        EventMessages messages = new EventMessages();
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[Authorize]
        [HttpPost("Create/Category")]
        public async Task<IActionResult> CreateCategory(CategoryRequestDto request)
        {
            try
            {
                var result = await _categoryService.CreateOrUpdateCategoryAsync(request);
                return Ok(new ResponseResult { Result = result, IsSuccess = true, Message = messages.Insert("Category") });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseResult { Result = false, IsSuccess = false, Message = messages.Required });
                throw;
            }
        }
    }
}
