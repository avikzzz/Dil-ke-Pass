using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.DTOs
{
    public class GetUserResponse
    {

        public int Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public char UserRole { get; set; }
        public char ActiveStatus { get; set; }
        public string Country { get; set; } = string.Empty;
        public char IsForeigner { get; set; } = 'N';
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime? LastLoginDate { get; set; }
        public char DocVerified { get; set; } = 'N';
        public DateTime? CreatedDate { get; set; }
  

    }
}
