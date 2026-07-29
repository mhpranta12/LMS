using LMS.Application;
using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        private readonly DbContextOptions<ApplicationDBContext> _options;
        public DbSet<Book> Books { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Member> Members { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            _options = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Fluent configurations go here 
            builder.Entity<Book>().HasKey(x => x.Id);
            builder.Entity<Branch>().HasKey(x => x.Id);
            builder.Entity<Member>().HasKey(x => x.Id);

            builder.Entity<Book>().
                            HasOne(b => b.BookBranch)
                            .WithMany()
                            .HasForeignKey(b => b.BranchId);
        }
    }
}
