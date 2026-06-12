using DilkePass.Application.Users.DTOs;
using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenServices _jwtTokenService;
        public AuthenticateUserHandler(IUserRepository repository, IJwtTokenServices jwtTokenService)
        {
            _userRepository = repository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserCommand userCommand)
        {
            
            var user = await _userRepository.GetUserbyEmailAsync(userCommand.EmailId);
            if (user == null)
                throw new Exception("User Does not Exists. Kindly Register");

            if (user.Password != userCommand.Password)
                throw new Exception("Password is Wrong");
            if (user.ActiveStatus == 'N')
                throw new Exception("User is Inactive.Kindly contact support !");
            var token = _jwtTokenService.GenerateToken(user);

            user.UpdateLastLoginTime();
            await _userRepository.SaveChangesAsync();

            return new AuthenticateUserResponse
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRole = user.UserRole == 'T' ? "Tourist" : "Admin",
                EmailId = user.EmailId,
                Token = token
            };
        }
        //public async Task<AuthenticateUserResponse> UserLoginAuthentication( AuthenticateUserCommand UserCommand)
        //{
        //    User result;
        //    if (string.IsNullOrWhiteSpace(UserCommand.PhoneNumber) && string.IsNullOrWhiteSpace(UserCommand.EmailId))
        //        throw new ArgumentException("Please enter either Phone Number or EmailId");
        //    if (!string.IsNullOrWhiteSpace(UserCommand.EmailId))
        //    {
        //        result = await _userRepository.AuthenticateUserbyEmailAsync(UserCommand.EmailId, UserCommand.Password);
          
              
        //    }
        //    else
        //    {
        //        result = await _userRepository.AuthenticateUserbyPhoneNumberAsync(UserCommand.PhoneNumber, UserCommand.Password);
                
        //    }
        //    if (result == null)
        //        throw new Exception("User Not Found");
        //    return new AuthenticateUserResponse
        //    {
        //        UserId = result.Id,
        //        UserName = result.UserName,
        //        EmailId = result.EmailId,
        //        UserRole = result.UserRole == 'T' ? "Tourist" : "Admin"
        //    };
        //}
    }
}
