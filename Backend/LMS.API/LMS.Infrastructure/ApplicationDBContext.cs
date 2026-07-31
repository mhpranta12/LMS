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
        public DbSet<Category> Category { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            _options = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------- Role -> User (1:M) ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade); // don't allow deleting a role in use


            // ---------- Branch -> Member (1:M) ----------
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Branch)
                .WithMany(b => b.Members)
                .HasForeignKey(m => m.BranchId)
                .OnDelete(DeleteBehavior.Cascade);


            // ---------- Category -> Book (1:M) ----------
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            // ---------- Member -> Loan (1:M) ----------
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(l => l.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Unique constraints ----------
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(m => m.Email).IsUnique();

        }
    }
 }