using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.DTOs
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }

    }
}
