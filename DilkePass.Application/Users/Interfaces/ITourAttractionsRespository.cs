using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Interfaces
{
    public interface ITourAttractionsRespository
    {
        Task<int> CreateTouristPlacesAsync(TourAttractions tourAttractions);

        Task<List<TourAttractions>> GetTourAttractionsbyStateAsync(string state);

        Task<bool> IsPlaceExists(string placeName);

        Task<TourAttractions?> GetTourAttractionById(int placeId);
    }
}
