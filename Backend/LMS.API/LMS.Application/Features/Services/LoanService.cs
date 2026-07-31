using LMS.Application.Dtos.LoanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class LoanService : ILoanService
    {
        public Task<LoanRequestDto> CreateLoanAsync(LoanRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLoanAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanResponseDto> GetLoanByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanRequestDto> UpdateLoanAsync(LoanRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
