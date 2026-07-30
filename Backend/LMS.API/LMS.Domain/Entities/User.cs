using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class User:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = default!;

        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }

        public ICollection<Loan>? IssuedLoans { get; set; } = new List<Loan>();
    }
}
