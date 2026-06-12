using DilkePass.Application.Users.DTOs;
using DilkePass.Application.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Queries.GetPlaces
{
    public class GetTourAttractionbyStateHandler
    {
        private readonly ITourAttractionsRespository _tourAttractRepos;

        public GetTourAttractionbyStateHandler(ITourAttractionsRespository tourAttractions)
        {
                _tourAttractRepos = tourAttractions;
        }


        public async Task<List<GetTouristPlacesByStateResponse>> GetTouristPlacesByState(GetTourAttractionbyStateQuery query)
        {
            if (string.IsNullOrWhiteSpace(query?.State))
                throw new ArgumentException("Provide a valid state.", nameof(query.State));

            var result = await _tourAttractRepos.GetTourAttractionsbyStateAsync(query.State);

            if (result == null || !result.Any())
                throw new KeyNotFoundException("No tourist places found for the specified state.");

            return result.Select(t => new GetTouristPlacesByStateResponse
            {
                Id = t.Id,
                PlaceName = t.PlaceName,
                Address = t.Address,
                State = t.State,
                Category = t.Category,
                OpenTime = t.OpenTime,
                CloseTime = t.CloseTime,
                NumberOfDaysOpen = t.NumberOfDaysOpen,
                DayClosed = t.DayClosed,
                Description = t.Description,
                Comments = t.Comments
            }).ToList();
        }

    }
}
