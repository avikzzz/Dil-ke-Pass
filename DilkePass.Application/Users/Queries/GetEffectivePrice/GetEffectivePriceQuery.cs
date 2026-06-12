using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Queries.GetEffectivePrice
{
    public class GetEffectivePriceQuery
    {
        public int PlaceId { get; set; }
        public int VistorId  { get; set; }
        public DateTime DateOfVisit { get; set; }
    }
}
