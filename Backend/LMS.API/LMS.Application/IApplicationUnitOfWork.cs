using LMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application
{
    public interface IApplicationUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public IBranchRepository BranchRepository { get; }
        public IMemberRepository MemberRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ILoanRepository LoanRepository { get; }
        public IUserManagementRepository UserManagementRepository { get; }
        public IRoleManagementRepository RoleManagementRepository { get; }

    }
}
