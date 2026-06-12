using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class User : Entity<int>, IAudit
    {
        public string UserName { get; private set; } = string.Empty;
        public string EmailId { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public char UserRole { get; private set; }
        public char ActiveStatus { get; private set; }
        public string Country { get; private set; } = string.Empty;
        public char IsForeigner { get; private set; } = 'N';
        public string DocumentType { get; private set; } = string.Empty;
        public string DocumentNumber { get; private set; } = string.Empty;
        public DateTime? LastLoginDate { get; private set; }
        public char DocVerified { get; private set; } = 'N';
        public DateTime? CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }


        protected User()
        {
        }
        
        public static User CreateUser(string userName, string emailId, string phoneNumber, string password, string country, string createdBy)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(emailId) ||
                string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(country))
            {
                throw new Exception("User Details empty");
            }

            if (!emailId.Contains('@') || !emailId.Contains('.'))
            {
                throw new Exception("Invalid EmailId");
            }
            if (phoneNumber.Length < 10)
            {
                throw new Exception("Ivalid Phone Number");
            }
            if (password.Length <= 4 || password.Length >= 16)
            {
                throw new Exception("Password lenghth error");
            }

            char userRole = 'T';
            char activeStatus = 'Y';
            char isForeigner = 'Y';
            if (country == "IND")
            {
                isForeigner = 'N';
            }


            var user = new User
            {
                UserName = userName,
                EmailId = emailId,
                UserRole = userRole,
                ActiveStatus = activeStatus,
                IsForeigner = isForeigner,
                PhoneNumber = phoneNumber,
                Password = password,
                Country = country,
                CreatedBy = createdBy,
                UpdatedBy = createdBy,
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = DateTime.Now


            };

            return user;
        }
        
        public void UpdateUserDetails(string userName, string phoneNumber,string country, string updatedBy)
        {
            
            int IsUpdated = 0;
            if (this.ActiveStatus == 'N')
                throw new InvalidOperationException("User can not be modified. Only active users can be modified");
            if (!string.IsNullOrWhiteSpace(userName))
            {
                UpdateName(userName);
                IsUpdated = 1;
            }
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                UpdatePhoneNumber(phoneNumber);
                IsUpdated = 1;
            }
            if (!string.IsNullOrWhiteSpace(country))
            {
                UpdateCountry(country);
                IsUpdated = 1;
            }
            

            if (IsUpdated == 1)
            {
                this.UpdatedDate= DateTime.UtcNow;
                this.UpdatedBy = updatedBy;
            }
                    


        }
        private void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name can not be null or empty");
            if (name.Length < 2)
                throw new ArgumentException("Please provide full name");
            if (name.TrimStart() == UserName.TrimStart())
                throw new ArgumentException("New User name can not be same as old");
            UserName = name;
            
        }
        private void UpdatePhoneNumber( string number)
        {
            if (number.Length < 10)
                throw new ArgumentException("Invalid Phonenumber");
            if (number.Trim() == PhoneNumber.Trim())
                throw new ArgumentException("Phone number can not be same");
            PhoneNumber= number;
            
        }
        private void UpdateCountry( string country)
        {
            if (country == Country)
                throw new ArgumentException("Country can not be same");
            if (country.Trim() != "IND")
            {
                Country = country;
                IsForeigner = 'Y';
            }
            else
            {
                Country = country;
                IsForeigner = 'N';
            }
            
        }

        public void UpdatePassword(string oldPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("New Password can not be blank");
            if (oldPassword.Trim() == newPassword.Trim())
                throw new ArgumentException("New Password can not be same as old Password ");
            if (oldPassword != this.Password)
                throw new ArgumentException("oldPassword is not matching try again");

            Password = newPassword;
            UpdatedDate = DateTime.UtcNow;           
            
        }

        public void UpdateDocuments(string documentNo, string docType )
        {
            
            if (string.IsNullOrWhiteSpace(docType))
                throw new ArgumentException("Doc Type can not be empty !");
            if (string.IsNullOrWhiteSpace(documentNo))
                throw new ArgumentException(" Document can not be blank");
            if (docType.Trim() == this.DocumentType.Trim() && this.DocumentNumber.Trim() == documentNo.Trim())
                throw new ArgumentException("Provide a new Number for docType" + docType);       
            if (this.IsForeigner == 'Y' && docType != "Passport")
                throw new ArgumentException("Invalid document. Passport is mandatory");
            if (docType == "Passport" && documentNo.Length < 8)
                throw new ArgumentException("Document No. is Invalid");

            this.DocumentNumber = documentNo;
            this.DocumentType = docType;
            this.DocVerified = 'N';
            this.UpdatedDate = DateTime.UtcNow;
             

        }
        public void VerifyDocument(string verifiedBy)
        {
            
            if (string.IsNullOrWhiteSpace(DocumentNumber) || string.IsNullOrWhiteSpace(DocumentType))
                throw new ArgumentException("Document Number or Type is not present");
            this.DocVerified = 'Y';
            this.UpdatedBy = verifiedBy;
            this.UpdatedDate = DateTime.UtcNow;
        }
        public void ActiveStatusChange(bool isActive)
        {
            
            if (isActive)
            {
                this.ActiveStatus = 'Y';
                
            }               
            else
            {
                this.ActiveStatus = 'N';
                this.UpdatedDate = DateTime.UtcNow;

            }             
      
        }
        public void UpdateLastLoginTime()
        {
           
            this.LastLoginDate = DateTime.UtcNow;
        }
    }
            


}
