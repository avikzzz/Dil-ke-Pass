using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class Price: Entity<int>, IAudit
    {
        public int PlaceId { get; private set; }
        public string VisitorType { get;private set; }  = string.Empty;
        public decimal TicketPrice {  get; private set; }
        public DateTime EffectiveDate { get; private set; }
        public DateTime ExpriryDate { get; private  set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? UpdatedDate {  get; private set; }
        public string? UpdatedBy { get; private set; }
        public string? CreatedBy { get; private set; }

        public TourAttractions? Place { get; private set; }

        protected Price()
        {
                
        }
        // factory method for the creation of price

        public static Price CreatePrice(int placeId, string visitorType,decimal price, DateTime effectiveDate, DateTime expiryDate, string createdBy)
        {
            if (placeId <= 0)
                throw new ArgumentException("provide a valid placeId");
            if (string.IsNullOrWhiteSpace(visitorType))
                throw new ArgumentException("provide a valid Visitor Type");               
            if (price < 0)
                throw new ArgumentException("price can not be negative");            
            if (expiryDate <= effectiveDate)
                throw new ArgumentException("Expiry must be after effective date");
            

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new ArgumentException("No user data");

            return new Price
            {
                PlaceId = placeId,
                VisitorType = visitorType,
                TicketPrice = price,
                EffectiveDate = effectiveDate,
                ExpriryDate = expiryDate,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = createdBy,
                UpdatedDate = DateTime.UtcNow,
            };


        }


        public void UpdatePrice(decimal? price, DateTime? effectiveDate, DateTime? expiryDate, string? updatedBy )
        {
            bool isUpdated = false;
            if (price.HasValue && price.Value>=0)
            {
                this.TicketPrice = price.Value;
                isUpdated = true;
            }
            if (effectiveDate.HasValue && expiryDate.HasValue && effectiveDate.Value < expiryDate.Value)
            {
                this.EffectiveDate = effectiveDate.Value;
                this.ExpriryDate = expiryDate.Value;
                isUpdated = true;
            }
            if( expiryDate.HasValue && expiryDate.Value> this.EffectiveDate)
            {
                this.ExpriryDate = expiryDate.Value;
                isUpdated= true;
            }
            if (isUpdated)
            {
                this.UpdatedBy = updatedBy;
                this.UpdatedDate = DateTime.UtcNow;

            }
                      

        }
    }
}
