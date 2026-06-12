using DilkePass.Application.Users.Commands.CreatePrice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DilkePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly CreatePriceHandler _createPrice;

        public PriceController(CreatePriceHandler createPrice)
        {
                _createPrice = createPrice;
        }

        [HttpPost("NewPrice")]

        public async Task<IActionResult> CreatePrice([FromBody] CreatePriceCommand command)
        {
            if (command == null)
                return BadRequest("Provide valid input");
            var result= await _createPrice.CreatePriceAsync(command);
            return Ok(result);
        }

    }
}
