using LMS.Application.Dtos.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface IBookService
    {
        Task<BookRequestDto> CreateBookAsync(BookRequestDto request);
        Task<bool> UpdateBookAsync(BookRequestDto request);
        Task DeleteBookAsync(Guid id);
        Task<BookResponseDto> GetBookByIdAsync(Guid id);
        Task<IEnumerable<BookResponseDto>> GetAllBooksAsync();
    }
}
