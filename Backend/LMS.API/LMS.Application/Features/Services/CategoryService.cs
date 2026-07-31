using LMS.Application.Dtos.CategoryDtos;
using LMS.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly ILogger<ICategoryService> _logger;
        public CategoryService(IApplicationUnitOfWork unitOfWork, ILogger<ICategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<CategoryRequestDto> CreateOrUpdateCategoryAsync(CategoryRequestDto request)
        {
            try
            {
                if (request?.Id != Guid.Empty)
                {
                    var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

                    if (entity is null)
                    {
                        throw new NullReferenceException("No Entity were found");
                    }
                    else
                    {
                        entity.Name = request.Name;
                        entity.Description = request.Description;
                        _unitOfWork.CategoryRepository.Update(entity);
                        await _unitOfWork.CategoryRepository.SaveAsync();

                    }
                }
                else
                {
                    var entity = new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        Description = request.Description
                    };
                    await _unitOfWork.CategoryRepository.AddAsync(entity);
                    await _unitOfWork.CategoryRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create category. Exception = " + ex);
                throw ex;
            }

            return request;
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
