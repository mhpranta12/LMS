using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.MemberDtos
{
    public class MemberRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid BranchId { get; set; }
    }
}
