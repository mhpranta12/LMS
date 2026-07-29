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
        public string Name { get; set; }
        public bool IsBorrowed { get; set; }
        public Branch BookBranch { get; set; }
        public Guid BranchId { get; set; }
    }
}
