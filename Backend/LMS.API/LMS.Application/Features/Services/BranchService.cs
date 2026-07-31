using LMS.Application.Dtos.BookDtos;
using LMS.Application.Dtos.BranchDtos;
using LMS.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Services
{
    public class BranchService : IBranchService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly ILogger<IBranchService> _logger;
        public BranchService(IApplicationUnitOfWork unitOfWork, ILogger<IBranchService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BranchRequestDto> CreateOrUpdateBranchAsync(BranchRequestDto request)
        {
            try
            {
                if (request?.Id != Guid.Empty)
                {
                    var entity = await _unitOfWork.BranchRepository.GetByIdAsync(request.Id);

                    if (entity is null)
                    {
                        throw new NullReferenceException("No Entity were found");
                    }
                    else
                    {
                        entity.Name = request.Name;
                        entity.Name = request.Name;
                        entity.Address = request.Address;
                        entity.Phone = request.Phone;
                        _unitOfWork.BranchRepository.Update(entity);
                        await _unitOfWork.BranchRepository.SaveAsync();

                    }
                }
                else
                {
                    var entity = new Branch()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        Address = request.Address,
                        Phone = request.Phone,

                        
                    };
                    await _unitOfWork.BranchRepository.AddAsync(entity);
                    await _unitOfWork.BookRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create book. Exception = " + ex);
                throw ex;
            }

            return request;
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
