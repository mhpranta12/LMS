using LMS.Application.Dtos.BookDtos;
using LMS.Application.Dtos.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface IBranchService
    {
        Task<BranchRequestDto> CreateOrUpdateBranchAsync(BranchRequestDto request);
        Task DeleteBranchAsync(Guid id);
        Task<BranchResponseDto> GetBranchByIdAsync(Guid id);
        Task<IEnumerable<BranchResponseDto>> GetAllBranchesAsync();
    }
}
