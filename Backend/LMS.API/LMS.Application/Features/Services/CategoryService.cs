using LMS.Application.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryRequestDto> CreateCategoryAsync(CategoryRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryRequestDto> UpdateCategoryAsync(CategoryRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
