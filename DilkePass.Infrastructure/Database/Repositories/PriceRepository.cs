using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Infrastructure.Database.Repositories
{
    public class PriceRepository: IPriceRepository
    {
        private readonly DilkePassDBContext _context;

        public PriceRepository(DilkePassDBContext context)
        {
                _context = context;
        }

        public async Task<int> CreatePriceAsync(Price prices)
        {
            await _context.Prices.AddAsync(prices);

            
            return prices.Id;

        }

        public async Task<TouristType?> GetVisitorType(string type)
        {
            var touristType = await _context.TouristTypes
                .FirstOrDefaultAsync(t => t.TouristTypeCode == type);
            return touristType;
        }

        public async Task<bool> IsPriceExist(int placeId, string visitorType, DateTime effectiveDate, DateTime expiryDate)
        {
            var isExist = await _context.Prices
                .AnyAsync(t => t.PlaceId == placeId && t.VisitorType == visitorType && t.EffectiveDate <= expiryDate && t.ExpriryDate >= effectiveDate);

            return isExist; 
        }


        public async Task<Price> GetEffectivePriceAsync(int placeId, string visitorType, DateTime visitDate)
        {
            var price = await _context.Prices
                .Where(c=>c.VisitorType==visitorType && c.PlaceId==placeId && c.EffectiveDate<=visitDate && c.ExpriryDate>visitDate)
                .FirstOrDefaultAsync();
            return price;

        }
    }
}
