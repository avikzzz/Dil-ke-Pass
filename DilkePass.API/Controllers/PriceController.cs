using DilkePass.Application.Users.Commands.CreatePrice;
using DilkePass.Application.Users.Queries.GetEffectivePrice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DilkePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly CreatePriceHandler _createPrice;
        private readonly GetEffectivePriceQueryHandler _effectivePrice;

        public PriceController(CreatePriceHandler createPrice, GetEffectivePriceQueryHandler effectivePrice)
        {
                _createPrice = createPrice;

                _effectivePrice = effectivePrice;
        }

        [HttpPost("NewPrice")]

        public async Task<IActionResult> CreatePrice([FromBody] CreatePriceCommand command)
        {
            if (command == null)
                return BadRequest("Provide valid input");
            var result= await _createPrice.CreatePriceAsync(command);
            return Ok(result);
        }


        // testing purpose
        [HttpGet("EffPrice")]
        public async Task<IActionResult> GetEffectivePrice([FromQuery] GetEffectivePriceQuery effPrice)
        {
            if (effPrice == null)
                return BadRequest("wrong input");

            var price = await _effectivePrice.GetEffectivePriceAsync(effPrice);

            return Ok(price);
        }

    }
}
