using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.BookDtos
{
    public class BookRequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public bool IsBorrowed { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
