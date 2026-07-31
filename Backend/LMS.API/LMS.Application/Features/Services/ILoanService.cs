using LMS.Application.Dtos.LoanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public interface ILoanService
    {
        Task<LoanRequestDto> CreateLoanAsync(LoanRequestDto request); 
        Task<LoanRequestDto> UpdateLoanAsync(LoanRequestDto request); 
        Task DeleteLoanAsync(Guid id); 
        Task<LoanResponseDto> GetLoanByIdAsync(Guid id);
        Task<IEnumerable<LoanResponseDto>> GetAllLoansAsync();
    }
}
