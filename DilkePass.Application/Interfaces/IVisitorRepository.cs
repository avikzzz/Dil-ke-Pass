using DilkePass.Application.Users.Queries.GetEffectivePrice;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Interfaces
{
    public interface IVisitorRepository
    {
        //public string GetVistorTypeByVisitorId(int visitorId);

        public Task<Tourist> GetParentUserbyVisitor(int visitorId);
         
        public Task<string> GetVistorTypeByVistorAge (int vistorAge);

        public Task<List<Tourist>> GetVisitorsbyParentUser(int userId);

        public Task AddVisitorAsync (Tourist visitor);
    }
}
