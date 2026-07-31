using LMS.Application.Dtos.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface IRoleManagementService
    {
        Task<UserRoleDto> CreateRoleAsync(UserRoleDto request); 
        Task<UserRoleDto> UpdateRoleAsync(UserRoleDto request); 
        Task DeleteRoleAsync(Guid id); 
        Task<UserRoleDto> GetRoleByIdAsync(Guid id);
        Task<IEnumerable<UserRoleDto>> GetAllRolesAsync();
    }
}
