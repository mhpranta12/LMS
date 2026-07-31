using LMS.Application.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface ICategoryService
    {
        Task<CategoryRequestDto> CreateCategoryAsync(CategoryRequestDto request); 
        Task<CategoryRequestDto> UpdateCategoryAsync(CategoryRequestDto request); 
        Task DeleteCategoryAsync(Guid id); 
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();

    }
}
