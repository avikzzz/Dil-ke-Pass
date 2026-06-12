using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class Tourist: Entity<int>
    {
        public int UserId { get; private set; }
        public string TouristName { get; private set; }= string.Empty;
        public DateTime TouristDOB { get; private set; }
        public char Gender { get; private set; }
        public string? ParentRelation { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        
        public User? User { get; private set; }



        protected Tourist()
        {
                
        }

        public static Tourist CreateTourist(int userId,  string touristName, DateTime dob, char Gender, string parentRelation)
        {
            if (string.IsNullOrWhiteSpace(touristName))
                throw new ArgumentException("Tourist name is required");

            if (string.IsNullOrWhiteSpace(parentRelation))
                throw new ArgumentException("Parent relation is required");

            if (dob >= DateTime.UtcNow)
                throw new ArgumentException("Invalid DOB");

            Tourist tourist = new Tourist()
            {
                UserId = userId,
                TouristName = touristName,
                TouristDOB = dob,
                Gender = Gender,
                ParentRelation = parentRelation,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            return tourist;
        }

        public void UpdateTourist(string touristName, DateTime dob, string parentRelation)
        {
            if (string.IsNullOrWhiteSpace(touristName))
                throw new ArgumentException("Tourist name is required");
            if (TouristName == touristName)
                throw new ArgumentException("Nothing Updated");
         

            if (dob >= DateTime.UtcNow)
                throw new ArgumentException("Invalid DOB");
            if ( TouristDOB == dob)
                throw new ArgumentException("Nothing Updated");
            TouristName = touristName;
            TouristDOB = dob;
            UpdatedDate = DateTime.UtcNow;
        }


        public void DeleteTourist()
        {
            IsDeleted = true;
        }

        

    }
    

}
