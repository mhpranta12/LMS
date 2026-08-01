using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities.Auth
{
    public class UserTokenRecord : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiredOn { get; set; }
    }
}
