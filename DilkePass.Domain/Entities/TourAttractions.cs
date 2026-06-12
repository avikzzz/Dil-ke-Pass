using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public  class TourAttractions: Entity<int>, IAudit
    {
        public string PlaceName { get; private set; } = string.Empty;
        public string Address   { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public TimeSpan OpenTime { get; private set; }
        public TimeSpan CloseTime   { get; private set; }
        public string Comments { get; private set; } = string.Empty;

        public int? NumberOfDaysOpen  { get; private set; }
        public string DayClosed { get; private set; } = string.Empty;
        public DateTime? CreatedDate { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string? UpdatedBy { get; private set; } = string.Empty;

        private TourAttractions()
        {
                
        }

        //Factory method used to create Entity
        public static TourAttractions CreateTouristAttraction(string placeName, string address, string state, string? description, 
            string category, TimeSpan openTime, TimeSpan closeTime,string? comments,int numberOfDaysOpen, string? dayClosed, string createdBy)
        {
            if(string.IsNullOrWhiteSpace(placeName))
                throw new ArgumentNullException("provide a name");
            if(string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("address is required");
            if(string.IsNullOrWhiteSpace(state))
                throw new ArgumentNullException("state is required");
            if(string.IsNullOrWhiteSpace(description))
                description = "Please check Govt. site for more details";
            if (string.IsNullOrWhiteSpace(category)) category = "India";
            if (openTime >= closeTime)
                throw new ArgumentException("open time should be less than close time ");
            if(string.IsNullOrWhiteSpace(comments))
                comments = string.Empty;
            if (numberOfDaysOpen < 0 || numberOfDaysOpen>7)
                throw new ArgumentException("Provide a valid number of days in a week");
            if (string.IsNullOrWhiteSpace(dayClosed))
                dayClosed = "no close";

            return new TourAttractions
            {
                PlaceName= placeName,
                Address= address,
                State= state,
                Description= description,
                Category= category,
                OpenTime= openTime,
                CloseTime= closeTime,
                Comments= comments,
                NumberOfDaysOpen= numberOfDaysOpen,
                DayClosed= dayClosed,
                CreatedDate = DateTime.UtcNow,
                CreatedBy= createdBy,
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = createdBy
                
               

            };
        }

        public void UpdateDescription (string description, string? updatedBy)
        {
            if (description == this.Description || string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("You have not changed any description");

            this.Description = description;
            if (!string.IsNullOrWhiteSpace(updatedBy))
            {
                UpdatedBy = updatedBy;
                UpdatedDate = DateTime.UtcNow;
            }

        }
        public void UpdateOpenCloseDate(TimeSpan? openTime, TimeSpan? closeTime, int? numberOfDaysOpen, string? dayClosed, string UpdatedBy)
        {
            bool isUpdated = false;
            if(openTime.HasValue && closeTime.HasValue && openTime< closeTime)
            {
                this.OpenTime = openTime.Value;
                this.CloseTime  = closeTime.Value;
                isUpdated = true;
            }
            if (!string.IsNullOrWhiteSpace(dayClosed))
            {
                this.DayClosed = dayClosed;
                isUpdated = true;
            }
            if(numberOfDaysOpen>0 && numberOfDaysOpen<7 && numberOfDaysOpen != this.NumberOfDaysOpen)
            {
                this.NumberOfDaysOpen = numberOfDaysOpen.Value;    // nullable to may non-nullable type. Hence, .Value is used to compare or assign only the actual value.
                isUpdated = true; 
            }
            if(isUpdated && !string.IsNullOrWhiteSpace(UpdatedBy)) 
            {
                this.UpdatedBy = UpdatedBy;
                this.UpdatedDate = DateTime.UtcNow;

            }
        }
    }
}
