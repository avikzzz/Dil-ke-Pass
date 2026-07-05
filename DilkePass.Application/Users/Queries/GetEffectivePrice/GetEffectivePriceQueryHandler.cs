using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Queries.GetEffectivePrice
{
    public class GetEffectivePriceQueryHandler
    {
        //placeId
        //visitorId
        //DateOfVisit
        private readonly IPriceRepository _priceRepository;
        private readonly IVisitorRepository _visitorRepository;
        public GetEffectivePriceQueryHandler(IPriceRepository priceRepository, IVisitorRepository visitorRepository)
        {
            _priceRepository = priceRepository;
            _visitorRepository = visitorRepository;
         }
        public async Task<decimal> GetEffectivePriceAsync( GetEffectivePriceQuery getEffectivePriceQuery)
        {
            // visitorId die visitor type fetch korbo-- not possible. Visitor Type is a master table having all the types.
            // Need to find the appropriate visitor type
            string visitorType;
            var touristWithParent = await _visitorRepository.GetParentUserbyVisitor(getEffectivePriceQuery.VistorId);


            if (touristWithParent == null)
                throw new KeyNotFoundException("Tourist Does not exist");
            if (touristWithParent.User.IsForeigner == 1)
            {
                visitorType = "FRN";
            }
            else
            {
                var visitorAge = CalculateAgefromDOB(touristWithParent.TouristDOB);  //age calculate hoe gelo
                visitorType = await _visitorRepository.GetVistorTypeByVistorAge(visitorAge);
            }
                
            if (visitorType == null)
                throw new ArgumentNullException("Visitor Type not Set for the Visitor. Contact Admin");

            var price = await _priceRepository.GetEffectivePriceAsync(getEffectivePriceQuery.PlaceId, visitorType, getEffectivePriceQuery.DateOfVisit);

            if (price == null)
                throw new NullReferenceException("No Price exists. Contact admin");

            return price.TicketPrice;
            
        }

        private int CalculateAgefromDOB( DateTime dob)
        {
            var today= DateTime.Today;

            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age))
            {
                --age;
            }

            return age;
        }
    }
}
