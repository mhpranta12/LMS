using LMS.Application.Dtos.AccountDtos;
using LMS.Application.Interfaces;
using LMS.Domain;
using LMS.Domain.Entities;
using LMS.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LMS.Application.Features.Services.UserManagementService;

namespace LMS.Application.Features.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IApplicationDBContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ILogger<UserManagementService> _logger;

        public UserManagementService(
            IApplicationUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator,
            IApplicationDBContext context,
            ILogger<UserManagementService> logger)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _logger = logger;
            _context = context;
        }

        public async Task<LoginResponseDto> SignInAsync(LoginRequestDto request)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);

            // Same error for "no user" and "wrong password" — don't leak which one failed
            if (user is null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Failed sign-in attempt for email {Email}", request.Email);
                throw new UnauthorizedException("Invalid email or password.");
            }

            var roles = new List<string> { user.Role.Name };
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, roles);

            _logger.LogInformation("User {UserId} signed in successfully", user.Id);

            return new LoginResponseDto
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                Email = user.Email,
                Role = user.Role.Name
            };
        }
        public async Task<UserRequestDto> CreateUserAsync(UserRequestDto request)
        {
            var existingByEmail = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (existingByEmail is not null)
                throw new ValidationException("A user with this email already exists.");

            var existingByUsername = await GetByUsernameAsync(request.Username);
            if (existingByUsername is not null)
                throw new ValidationException("A user with this username already exists.");

            var passwordHash = _passwordHasher.Hash(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                RoleId = request.RoleId,
                BranchId = request.BranchId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.UserRepository.SaveAsync();

            _logger.LogInformation("User {UserId} created with username {Username}", user.Id, user.Username);

            request.Id = user.Id;
            return request;
        }
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.User
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username)??null;
        }
        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRequestDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRequestDto> UpdateUserAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
