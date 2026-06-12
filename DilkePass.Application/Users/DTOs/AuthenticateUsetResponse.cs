using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.DTOs
{
    public class AuthenticateUserResponse
    {
        public string Token { get; set; }
        public DateTime TokenExpiry { get; set; }
        public string  UserName { get; set; }
        public int UserId   { get; set; }
        
        public string EmailId { get; set; }
        public string UserRole { get; set; }


    }
}
