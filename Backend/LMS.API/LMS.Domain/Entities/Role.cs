using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Role : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!; // Admin, Librarian, Member
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
