using DilkePass.Application.Visitors.Commands.AddVisitors;
using DilkePass.Application.Visitors.Queries.GetVisitors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DilkePass.API.Controllers
{
    public class VisitorController : Controller
    {
        private readonly AddVisitorsCommandHandler _handler;
        private readonly GetVisitorDetailsQueryHandler _queryHandler;
        public VisitorController(AddVisitorsCommandHandler handler, GetVisitorDetailsQueryHandler queryHandler)
        {
            _handler = handler;
            _queryHandler = queryHandler;
                    
        }



        [HttpPost("Add")]
        public async Task<IActionResult> AddVisitorAsync([FromBody]AddVisitorsCommand command)
        {
            if (command == null)
                return BadRequest("Input error");
            var visitor = await _handler.AddVisitorsAsync(command);

            return Ok(visitor);
        }

        [HttpGet("byUserId")]
        public async Task<IActionResult> GetVisitorsbyUserId(int userId)
        {
            var visitors = await _queryHandler.GetVisitorbyUserAsync(userId);

            if(visitors == null)
            {
                return NotFound();
            }
            return Ok(visitors);
        }
    }
}
