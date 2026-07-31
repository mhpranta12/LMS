using LMS.Application.Dtos.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class RoleManagementService : IRoleManagementService
    {
        public Task<UserRoleDto> CreateRoleAsync(UserRoleDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRoleDto> GetRoleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRoleDto> UpdateRoleAsync(UserRoleDto request)
        {
            throw new NotImplementedException();
        }
    }
}
