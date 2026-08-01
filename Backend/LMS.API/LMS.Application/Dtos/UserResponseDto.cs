using LMS.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos
{
    public class UserResponseDto
    {
        public string AuthToken { get; set; }
        public List<int> Permissions { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RefreshToken { get; set; }
        public static UserResponseDto From(List<int> permissionSet, UserTokenRecord tokenRecord)
        {
            var userResponse = new UserResponseDto
            {
                AuthToken = tokenRecord.AuthToken,
                Permissions = permissionSet,
                ExpireDate = DateTime.UtcNow.AddDays(30),
                RefreshToken = tokenRecord.RefreshToken,
            };

            return userResponse;
        }
    }
}
