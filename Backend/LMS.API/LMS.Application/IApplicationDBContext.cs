using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application
{
    public interface IApplicationDBContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Branch> Branches { get; set; }
        DbSet<Member> Members { get; set; }
        DbSet<Category> Category { get; set; }
    }
}
