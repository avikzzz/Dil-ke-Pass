using DilkePass.Application.Users.Commands.CreateUser;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainUser = DilkePass.Domain.Entities.User;
namespace DilkePass.Application.Users.Interfaces
{
    public interface IUserRepository
    {
        
        Task AddNewUserAsync(DomainUser user);
        Task<User?> GetUserbyEmailAsync(string emailId);
        //Task<User> GetUserbyPhoneNumberAsync(string phoneNum, string password);
        
        Task<DomainUser?> GetUserByIdAsync(int id);
        Task<bool> IsEmailExists(string emailId);

        Task SaveChangesAsync();

    }
}
