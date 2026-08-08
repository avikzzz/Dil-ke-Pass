using DilkePass.Application.Interfaces;
using DilkePass.Application.Visitors.DTOs;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Visitors.Commands.AddVisitors
{
     public class AddVisitorsCommandHandler
     {
        private readonly IVisitorRepository _visitorRepos;
        private readonly IUserRepository _userRepos;
        private readonly IDilkePassDBContext _context;
        public AddVisitorsCommandHandler(IVisitorRepository  visitorRepos, IUserRepository userRepository, IDilkePassDBContext context)
        {
                _visitorRepos = visitorRepos;
                _userRepos = userRepository;
                _context = context;
        }
        public async Task<AddVisitorResponse> AddVisitorsAsync(AddVisitorsCommand command)
        {
            var checkUser = await _userRepos.GetUserByIdAsync(command.userId);
            if (checkUser == null)
            {
                throw new InvalidOperationException("User not Present");
            }

            if (checkUser.ActiveStatus != 'Y')
                throw new InvalidOperationException("User Inactive");
            List<Tourist> visitor = await _visitorRepos.GetVisitorsbyParentUser(command.userId);
            if (visitor.Count() >= 4)
            {
                throw new ArgumentOutOfRangeException("Maximum 4 visitors for a Single User");
            }

            // calling domain directly
            var newTourist = Tourist.CreateTourist(command.userId, command.touristName, command.dob,
                command.Gender, command.ParentRelation);

            //saving to database;
            await _visitorRepos.AddVisitorAsync(newTourist);

            await _context.SaveChangesAsync();

            var newTouristResponse = new AddVisitorResponse()
            {
                visitorId = newTourist.Id,
                visitorName = newTourist.TouristName,
                parentRelation = newTourist.ParentRelation 
            }; 
            
            return newTouristResponse;

        }
    }
}
