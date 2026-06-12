using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Commands.CreateUser
{//string userName, string emailId,  string phoneNumber, string password, string country, string createdBy
    public class CreateUserCommand
    {
        public string UserName { get; set; }
        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }

        public string CreatedBy { get; set; }
        


    }
}
