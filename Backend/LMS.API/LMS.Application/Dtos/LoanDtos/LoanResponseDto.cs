using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.LoanDtos
{
    public class LoanResponseDto
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid MemberId { get; set; }
        public Guid BookId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
