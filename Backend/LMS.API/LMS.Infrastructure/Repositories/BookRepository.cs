using LMS.Application;
using LMS.Application.Dtos.BookDtos;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly IApplicationDBContext _applicationDBContext;
        public BookRepository(ApplicationDBContext context,IApplicationDBContext applicationDBContext) : base(context)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<IEnumerable<Book>> GetAllBookByBranchIdAsync(Guid branchId)
        {
            var result = new List<Book>();
            result = await _applicationDBContext.Books
                                    .Where(x => x.BranchId == branchId)
                                    .ToListAsync();
            return result;
        }
    }
}
