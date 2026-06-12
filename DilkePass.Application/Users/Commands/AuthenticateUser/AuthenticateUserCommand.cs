using DilkePass.Application.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand
    {
        public string? EmailId { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }       


    }
}
