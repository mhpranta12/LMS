using LMS.Application.Dtos.BookDtos;
using LMS.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly ILogger<IBookService> _logger;
        public BookService (IApplicationUnitOfWork unitOfWork, ILogger<IBookService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BookRequestDto> CreateBookAsync(BookRequestDto request)
        {
            try
            {
                if(request?.Id != Guid.Empty)
                {
                    var entity = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

                    if (entity is null)
                    {

                    }
                    else
                    {
                        entity.Title = request.Title;
                        entity.Publisher = request.Publisher;
                        entity.IsBorrowed = false;
                        entity.BranchId = request.BranchId;
                        entity.CategoryId = request.CategoryId;
                        _unitOfWork.BookRepository.Update(entity);
                        await _unitOfWork.BookRepository.SaveAsync();

                    }
                }
                else
                {
                    var entity = new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = request.Title,
                        Publisher = request.Publisher,
                        IsBorrowed = false,
                        BranchId = request.BranchId,
                        CategoryId = request.CategoryId,
                    };
                    await _unitOfWork.BookRepository.AddAsync(entity);
                    await _unitOfWork.BookRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create book. Exception = " + ex);
                throw ex;
            }
            
            return request;
        }

        public async Task DeleteBookAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.BookRepository.GetByIdAsync(id);
                _unitOfWork.BookRepository.Delete(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete this book. Exception = " + ex);
                throw ex;
            }

        }

        public Task<IEnumerable<BookResponseDto>> GetAllBookByBranchIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BookResponseDto> GetBookByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.BookRepository.GetByIdAsync(id);
            var branch = await _unitOfWork.BranchRepository.GetByIdAsync((Guid)entity.BranchId);
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync((Guid)entity.CategoryId);

            var response = new BookResponseDto()
            {
                Title = entity.Title,
                Publisher = entity.Publisher,
                Branch = branch?.Name,
                Category = category?.Name,
            };
            return response;
        }

    }
}
