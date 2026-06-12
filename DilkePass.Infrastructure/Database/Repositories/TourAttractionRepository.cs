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
    public class TourAttractionRepository:ITourAttractionsRespository
    {
        private readonly DilkePassDBContext _context;

        public TourAttractionRepository(DilkePassDBContext context)
        {
                _context = context;
        }

        public async Task<int>  CreateTouristPlacesAsync(TourAttractions tourAttractions)
        {
            await _context.TourAttractions.AddAsync(tourAttractions);
            await _context.SaveChangesAsync();

            return tourAttractions.Id;
        }

        public async Task<List<TourAttractions>> GetTourAttractionsbyStateAsync(string state)
        {
            var result = await _context.TourAttractions
                .Where(t => t.State == state)
                .ToListAsync();

            return result;
            
           
        }

        public async Task<TourAttractions?> GetTourAttractionById(int placeId)
        {
            var result = await _context.TourAttractions
                .FindAsync(placeId);

            return result;
        }

        public async Task<bool> IsPlaceExists(string placeName)
        {
            bool isplaceExist= await _context.TourAttractions.AnyAsync(c=>c.PlaceName == placeName);

            return isplaceExist;
        }
    }
}
