using DilkePass.Application.Users.DTOs;
using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainUser= DilkePass.Domain.Entities.User;
namespace DilkePass.Application.Users.Queries.GetUser
{
    public class GetUserHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> GetUserbyId(GetUserQuery getUserQuery)
        {
            if(getUserQuery.Id <= 0 )
                throw new ArgumentOutOfRangeException("userId");
            var result = await _userRepository.GetUserByIdAsync(getUserQuery.Id);

            if (result == null)
                throw new Exception("User Not Found");
            return new GetUserResponse
            {
                Id = result.Id,
                UserName = result.UserName,
                PhoneNumber = result.PhoneNumber,
                UserRole = result.UserRole,
                EmailId = result.EmailId,
                Country = result.Country,
                IsForeigner = result.IsForeigner,
                DocumentType = result.DocumentType,
                DocumentNumber = result.DocumentNumber,
                LastLoginDate = result.LastLoginDate,
                DocVerified = result.DocVerified,
                CreatedDate = result.CreatedDate,
                ActiveStatus = result.ActiveStatus,



            };
           
        } 
        
    }
}
