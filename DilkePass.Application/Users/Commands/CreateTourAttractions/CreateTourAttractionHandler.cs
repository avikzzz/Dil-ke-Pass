using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DilkePass.Application.Users.Commands.CreateTourAttractions
{
    public class CreateTourAttractionHandler
    {
        private readonly ITourAttractionsRespository _tourRepository;

        public CreateTourAttractionHandler(ITourAttractionsRespository tourRepository)
        {
                _tourRepository = tourRepository;
        }

        public async Task<int> CreateTourAttractions(CreateTourAttractionCommand createTourCommand)
        {
            if (createTourCommand == null)
                throw new ArgumentNullException("provide valid inputs to create Tourist Attractions");

            var isExist = await _tourRepository.IsPlaceExists(createTourCommand.PlaceName);

            if (isExist)
                throw new ArgumentException("Place Already exists in the Database");


            //domain call
            var tourAttraction = TourAttractions.CreateTouristAttraction(
                createTourCommand.PlaceName,
                createTourCommand.Address,
                createTourCommand.State,
                createTourCommand.Description,
                createTourCommand.Category,
                createTourCommand.OpenTime,
                createTourCommand.CloseTime,
                createTourCommand.Comments,
                createTourCommand.NumberOfDaysOpen,
                createTourCommand.DayClosed,
                createTourCommand.CreatedBy


            );

            // repos call

            int placeId= await _tourRepository.CreateTouristPlacesAsync(tourAttraction);

            //return
            return placeId;
            
        }
    }
}
