using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Book:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public string? Publisher { get; set; }
        public Branch? BookBranch { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; } = default!;
    }
}
