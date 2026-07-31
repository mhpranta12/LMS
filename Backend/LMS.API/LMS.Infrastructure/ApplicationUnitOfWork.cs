using LMS.Application;
using LMS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        private readonly IApplicationDBContext _dbContext;
        public IBookRepository BookRepository { get; set; }
        public IBranchRepository BranchRepository { get; set; }
        public IMemberRepository MemberRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public ILoanRepository LoanRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IRoleManagementRepository RoleManagementRepository { get; set; }
        public ApplicationUnitOfWork(IApplicationDBContext dbContext,
            IBookRepository bookRepository,
            IBranchRepository branchRepository,
            IMemberRepository memberRepository,
            ICategoryRepository categoryRepository,
            ILoanRepository loanRepository,
            IUserRepository userRepository,
            IRoleManagementRepository roleManagementRepository)
            : base((DbContext)dbContext)
        {
            _dbContext = dbContext;
            BookRepository = bookRepository;
            BranchRepository = branchRepository;
            MemberRepository = memberRepository;
            CategoryRepository = categoryRepository;
            LoanRepository = loanRepository;
            UserRepository = userRepository;
            RoleManagementRepository = roleManagementRepository;
        }
    }
}
