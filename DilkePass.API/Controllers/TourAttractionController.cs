using DilkePass.Application.Users.Commands.CreateTourAttractions;
using DilkePass.Application.Users.Queries.GetPlaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DilkePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourAttractionController : ControllerBase
    {
        private readonly CreateTourAttractionHandler _createTourHandler;
        private readonly GetTourAttractionbyStateHandler _getTourAttractionbyStateHandler;

        public TourAttractionController(CreateTourAttractionHandler createTourHandler, GetTourAttractionbyStateHandler getByState)
        {
                _createTourHandler = createTourHandler;
                _getTourAttractionbyStateHandler = getByState;

        }

        [HttpPost("Create")]

        public async Task<IActionResult> CreateTourAttractions(CreateTourAttractionCommand command)
        {
            if (command == null)
                return BadRequest("Provide correct input");
            int placeId= await _createTourHandler.CreateTourAttractions(command);

            return Ok("Successfully added" + placeId);
        }

        [HttpGet("byState")]
        public async Task<IActionResult> GetTouristPlacesbyState([FromQuery]GetTourAttractionbyStateQuery query)
        {
            if (query == null)
                return BadRequest("state is empty");
            var result = await _getTourAttractionbyStateHandler.GetTouristPlacesByState(query);

            return Ok(result);
        }


        
    }
}
