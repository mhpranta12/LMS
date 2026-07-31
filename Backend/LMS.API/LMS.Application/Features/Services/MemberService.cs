using LMS.Application.Dtos.MemberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class MemberService : IMemberService
    {
        public Task<MemberRequestDto> CreateMemberAsync(MemberRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMemberAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MemberResponseDto> GetMemberByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MemberRequestDto> UpdateMemberAsync(MemberRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
