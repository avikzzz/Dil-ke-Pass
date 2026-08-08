using DilkePass.Application.Interfaces;
using DilkePass.Application.Visitors.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Visitors.Queries.GetVisitors
{
    public class GetVisitorDetailsQueryHandler
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IUserRepository _userRepository;

        public GetVisitorDetailsQueryHandler(IVisitorRepository visitorRepository, IUserRepository userRepository)
        {
                _visitorRepository  = visitorRepository;
                _userRepository = userRepository;
        }
        public async Task<List<GetvisitorDetailsResponse>> GetVisitorbyUserAsync( int userId)
        {
            var checkUser = await _userRepository.GetUserByIdAsync(userId);
            if (checkUser == null) 
                throw new KeyNotFoundException("User Not Found");

            var visitors = await _visitorRepository.GetVisitorsbyParentUser(userId);

            return visitors.Select(c => new GetvisitorDetailsResponse
            {
                VisitorId = c.Id,
                UserId = c.UserId,
                TouristName = c.TouristName,
                TouristDOB = c.TouristDOB,
                Gender  = c.Gender,
                ParentRelation = c.ParentRelation,
                CreatedDate = c.CreatedDate,
                UpdatedDate = c.UpdatedDate,

            }).ToList();

           
                

        } 
    }
}
