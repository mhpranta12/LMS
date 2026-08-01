using LMS.Application.Dtos.BookDtos;
using LMS.Domain.Entities;
using LMS.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LMS.Application.Features.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly ILogger<IBookService> _logger;
        public BookService(IApplicationUnitOfWork unitOfWork, ILogger<IBookService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BookRequestDto> CreateOrUpdateBookAsync(BookRequestDto request)
        {
            try
            {
                if (request?.Id != Guid.Empty)
                {
                    var entity = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

                    if (entity is null)
                    {
                        throw new NotFoundException("Book wasn't found.");
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
                if (entity is null)
                    throw new NotFoundException("Book wasn't found.");

                _unitOfWork.BookRepository.Delete(entity);
                await _unitOfWork.BookRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete book with id {BookId}", id);
                throw;
            }

        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBookByBranchIdAsync(Guid id)
        {
            var books = await _unitOfWork.BookRepository.GetAllBookByBranchIdAsync(id);
            if (!books.Any())
                return Enumerable.Empty<BookResponseDto>();

            var result = new List<BookResponseDto>();

            foreach (var book in books)
            {
                result.Add(new BookResponseDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Publisher = book.Publisher,
                    IsBorrowed = book.IsBorrowed,
                    Branch = book.BranchId.HasValue
                        ? await GetBranchNameByIDAsync(book.BranchId.Value)
                        : null,
                    Category = book.CategoryId.HasValue
                        ? await GetCategoryNameByIDAsync(book.CategoryId.Value)
                        : null
                });
            }

            return result;
        }
        public async Task<IEnumerable<BookResponseDto>> GetAllBookByCategoryIdAsync(Guid id)
        {
            var books = await _unitOfWork.BookRepository.GetAllBookByCategoryIdAsync(id);
            if (!books.Any())
                return Enumerable.Empty<BookResponseDto>();

            var result = new List<BookResponseDto>();

            foreach (var book in books)
            {
                result.Add(new BookResponseDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Publisher = book.Publisher,
                    IsBorrowed = book.IsBorrowed,
                    Branch = book.BranchId.HasValue
                        ? await GetBranchNameByIDAsync(book.BranchId.Value)
                        : null,
                    Category = book.CategoryId.HasValue
                        ? await GetCategoryNameByIDAsync(book.CategoryId.Value)
                        : null
                });
            }

            return result;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.BookRepository.GetAllBooksAsync();
            var result = new List<BookResponseDto>();

            foreach (var book in books)
            {
                result.Add(new BookResponseDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Publisher = book.Publisher,
                    IsBorrowed = book.IsBorrowed,
                    Branch = book.BranchId.HasValue
                        ? await GetBranchNameByIDAsync(book.BranchId.Value)
                        : "No Branch",
                    Category = book.CategoryId.HasValue
                        ? await GetCategoryNameByIDAsync(book.CategoryId.Value)
                        : "No Category"
                });
            }

            return result;
        }

        public async Task<BookResponseDto> GetBookByIdAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.BookRepository.GetByIdAsync(id);
                var branch = entity.BranchId.HasValue ? await _unitOfWork.BranchRepository.GetByIdAsync((Guid)entity.BranchId) : null;
                var category = entity.CategoryId.HasValue ? await _unitOfWork.CategoryRepository.GetByIdAsync((Guid)entity.CategoryId) : null;

                var response = new BookResponseDto()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Publisher = entity.Publisher,
                    IsBorrowed = entity.IsBorrowed,
                    Branch = branch?.Name ?? "No Branch",
                    Category = category?.Name ?? "No Category",
                };
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to fetch book info exception = " + ex);
                throw;
            }
        }
        // Utility Methods
        public async Task<string> GetBranchNameByIDAsync(Guid id)
        {
            var branch = await _unitOfWork.BranchRepository.GetByIdAsync(id);
            return branch.Name;
        }
        public async Task<string> GetCategoryNameByIDAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return category.Name;
        }
    }
}
