using LMS.Application.Dtos.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class UserManagementService : IUserManagementService
    {
        public Task<UserRequestDto> CreateUserAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRequestDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRequestDto> UpdateUserAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
