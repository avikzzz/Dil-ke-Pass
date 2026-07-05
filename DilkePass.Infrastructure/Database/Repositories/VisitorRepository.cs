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
    public class VisitorRepository:IVisitorRepository
    {
        private readonly DilkePassDBContext _context;

        public VisitorRepository(DilkePassDBContext context)
        {
            _context = context;
                            
        }


        public async Task<Tourist?> GetParentUserbyVisitor(int visitorId)
        {
            var tourist = await _context.Tourists
                .Include(c => c.User)
                .FirstOrDefaultAsync(v=>v.Id==visitorId);

            return tourist;
        }
         
        public async Task<string> GetVistorTypeByVistorAge(int vistorAge)
        {
            var tourType = await _context.TouristTypes
                .Where(c => c.MinAge <= vistorAge && c.MaxAge >= vistorAge && c.IsActive == true)
                .Select(c => c.TouristTypeCode)
                .FirstOrDefaultAsync();

            if (tourType == null)
            {
                tourType = "DFL";
            }

            return tourType;
        }
    }
}
