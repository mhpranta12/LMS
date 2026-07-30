using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Member:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Branch Branch { get; set; } = default!;
        public Guid BranchId { get; set; }
        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
