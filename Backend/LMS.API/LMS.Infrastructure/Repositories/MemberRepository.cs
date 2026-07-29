using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IRepository<Member>
    {
        public MemberRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
