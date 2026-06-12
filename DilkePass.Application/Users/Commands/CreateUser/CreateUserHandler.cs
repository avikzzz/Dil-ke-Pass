using DilkePass.Application.Users.DTOs;
using DilkePass.Application.Users.Commands.CreateUser;
using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepos;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepos = userRepository;      
        }


        
        public async Task<CreateUserResponse> CreateUserHandle(CreateUserCommand command)
        {
            bool isEmailExist = await _userRepos.IsEmailExists(command.EmailId);
            if (isEmailExist)
            {
                throw new ArgumentException(" EmailId already Exists in the system. Please Login or use a different EmailId");
            }
            //1.Domain call. See Application depends on Domain
            //Direct User theke call korchhi, cause ota static method

            var user = Domain.Entities.User.CreateUser(
                command.UserName,
                command.EmailId,
                command.PhoneNumber,
                command.Password,
                command.Country,
                command.CreatedBy
            );

            // 2. Saving to database
            await _userRepos.AddNewUserAsync(user);

            // 3. Show response.

            var newUser = new CreateUserResponse
            {
                Id= user.Id,
                UserName = user.UserName,
                EmailId = user.EmailId  
            };

            return newUser;

        }
    }
}
