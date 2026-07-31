using LMS.Application.Dtos.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class BranchService : IBranchService
    {
        public Task<BranchRequestDto> CreateBranchAsync(BranchRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBranchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BranchResponseDto>> GetAllBranchesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BranchResponseDto> GetBranchByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BranchRequestDto> UpdateBranchAsync(BranchRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
