using LMS.Application.Dtos.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface IUserManagementService
    {
        Task<UserRequestDto> CreateUserAsync(UserRequestDto request); 
        Task<UserRequestDto> UpdateUserAsync(UserRequestDto request); 
        Task DeleteUserAsync(Guid id); 
        Task<UserRequestDto> GetUserByIdAsync(Guid id);
    }
}
