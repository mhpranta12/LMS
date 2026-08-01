using LMS.Application.Dtos.LoanDtos;
using LMS.Domain.Entities;
using LMS.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class LoanService : ILoanService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly ILogger<LoanService> _logger;
        public LoanService (IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoanRequestDto> CreateOrUpdateLoanAsync(LoanRequestDto request)
        {
            try
            {
                if (request?.Id != Guid.Empty)
                {
                    var entity = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

                    if (entity is null)
                    {
                        throw new NotFoundException("Loan for this book wasn't found.");
                    }
                    else
                    {
                       entity.BookId = request.BookId;
                       entity.BorrowDate = DateTime.UtcNow.Date;
                       entity.ReturnDate = null;
                        _unitOfWork.LoanRepository.Update(entity);
                        await _unitOfWork.LoanRepository.SaveAsync();
                    }
                }
                else
                {
                   var entity = new Loan()
                   {
                       Id = Guid.NewGuid(),
                       BookId = request.BookId,
                       BorrowDate = DateTime.UtcNow.Date,
                       ReturnDate = null,
                   };
                    await _unitOfWork.LoanRepository.AddAsync(entity);
                    await _unitOfWork.LoanRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create book. Exception = " + ex);
                throw ex;
            }

            return request;
        }

        public Task DeleteLoanAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoanResponseDto>> GetAllLoansAsync()
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
