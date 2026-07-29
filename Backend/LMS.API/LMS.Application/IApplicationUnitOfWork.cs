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
        public IBranchRepository BranchRepository { get; }
        public IBookRepository BookRepository { get; }
        public IMemberRepository MemberRepository { get; }

    }
}
