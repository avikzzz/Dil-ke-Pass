using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class TouristAvailability: IAudit
    {
        public int PlaceId { get; private set; }
        public DateOnly VisitDate { get; private set; }
        public int TotalCapacity { get; private set; }
        public int BookedCount { get; private set; }

        public DateTime? CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string? UpdatedBy { get; private set;}
        public string? CreatedBy    { get; private set; }

        public TourAttractions? Place {  get; private set; }

        protected TouristAvailability()
        {
                
        }

        public static TouristAvailability CreateAvailability(int placeId, DateOnly visitDate, int totalCapacity, string createdBy)
        {
            if (placeId <= 0)
                throw new ArgumentException("PlaceId must be valid");

            if (totalCapacity <= 0)
                throw new ArgumentException("Capacity must be greater than 0");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new ArgumentException("CreatedBy is required");

            return new TouristAvailability
            {
                PlaceId = placeId,
                VisitDate = visitDate,
                TotalCapacity = totalCapacity,
                BookedCount = 0,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = createdBy,
                UpdatedBy = createdBy,
                UpdatedDate = DateTime.UtcNow
            };
        }
    }
}
