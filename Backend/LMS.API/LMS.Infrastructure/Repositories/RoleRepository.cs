using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleManagementRepository
    {
        public RoleRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
