using Azure.Core;
using LMS.Application;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly IApplicationDBContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;
        public UserRepository(ApplicationDBContext context, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher) : base(context)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.User
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email) ?? null;
        }
        public void Register()
        {
            // Register
            //var hash = _passwordHasher.Hash(request.Password);
            //var user = new User { Username = ..., Email = ..., PasswordHash = hash, RoleId = ... };
        }
        public void Login()
        {
            // Login
            //var user = await _userRepository.GetByEmailAsync(request.Email);
            //if (user is null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
            //    throw new Exception("Invalid credentials");

            //var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, roles);
        }

    }
}
