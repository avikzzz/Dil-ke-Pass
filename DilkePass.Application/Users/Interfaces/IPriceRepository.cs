using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Interfaces
{
    public interface IPriceRepository
    {
        public  Task<int> CreatePriceAsync(Price prices);

        public Task<TouristType?> GetVisitorType(string type);

        public Task<bool> IsPriceExist(int placeId, string visitorType, DateTime effectiveDate, DateTime expiryDate);

        public  Task<Price> GetEffectivePriceAsync(int placeId, string visitorType, DateTime visitDate);
    }
}
