using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.BookDtos
{
    public class BookResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsBorrowed { get; set; }
        public string? Publisher { get; set; }
        public string? Branch { get; set; }
        public string? Category { get; set; }
    }
}
