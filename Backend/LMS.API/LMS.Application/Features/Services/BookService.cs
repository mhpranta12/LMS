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
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create book. Exception = " + ex);
                throw ex;
            }
            
            return request;
        }

        public Task DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookResponseDto> GetBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookRequestDto> UpdateBookAsync(BookRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
