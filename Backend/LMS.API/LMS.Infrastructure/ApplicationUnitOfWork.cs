using LMS.Application;
using LMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure
{
    public class ApplicationUnitOfWork :IApplicationUnitOfWork
    {
        private readonly IApplicationDBContext _dBContext;
        public IBookRepository BookRepository { get; set; }
        public IBranchRepository BranchRepository { get; set;}
        public IMemberRepository MemberRepository { get; set;}
        public ICategoryRepository CategoryRepository { get; set;}
        public ILoanRepository LoanRepository { get; set;}
        public IUserManagementRepository UserManagementRepository { get; set;}
        public IRoleManagementRepository RoleManagementRepository { get; set;}
        public ApplicationUnitOfWork(IApplicationDBContext dBContext, IBookRepository bookRepository, IBranchRepository branchRepository, IMemberRepository memberRepository, ICategoryRepository categoryRepository, ILoanRepository loanRepository, IUserManagementRepository userManagementRepository, IRoleManagementRepository roleManagementRepository)
        {
            _dBContext = dBContext;
            BookRepository = bookRepository;
            BranchRepository = branchRepository;
            MemberRepository = memberRepository;
            CategoryRepository = categoryRepository;
            LoanRepository = loanRepository;
            UserManagementRepository = userManagementRepository;
            RoleManagementRepository = roleManagementRepository;
        }
    }
}
