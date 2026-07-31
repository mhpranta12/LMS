using LMS.Application.Dtos.MemberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface IMemberService
    {
        Task<MemberRequestDto> CreateMemberAsync(MemberRequestDto request); 
        Task<MemberRequestDto> UpdateMemberAsync(MemberRequestDto request); 
        Task DeleteMemberAsync(Guid id); 
        Task<MemberResponseDto> GetMemberByIdAsync(Guid id);
        Task<IEnumerable<MemberResponseDto>> GetAllMembersAsync();

    }
}
