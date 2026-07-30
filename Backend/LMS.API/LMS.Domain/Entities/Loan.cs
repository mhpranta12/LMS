using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Loan : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "Active";
        public Guid BookId { get; set; }
        public Member Member { get; set; } = default!;
        public Guid MemberId { get; set; }
    }
}
