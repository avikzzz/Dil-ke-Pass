using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Infrastructure.Database.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DilkePassDBContext _context;

        public UserRepository(DilkePassDBContext context)
        {
                _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task AddNewUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            var userResult = await _context.Users
                .FirstOrDefaultAsync(c => c.Id == userId);
            return userResult;
                
        }

        public async Task<bool> IsEmailExists(string emailId)
        {
            var result = await _context.Users
                .AnyAsync(c => c.EmailId == emailId);

            return result;
                
        }

        public async Task<User?> GetUserbyEmailAsync(string emailId)
        {
            var user = await _context.Users
                .Where(w => w.EmailId == emailId)
                .FirstOrDefaultAsync();
            return user;
        }

        
    }
}
