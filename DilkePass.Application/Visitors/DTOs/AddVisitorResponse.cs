using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Visitors.DTOs
{
    public class AddVisitorResponse
    {
        public int visitorId { get; set; }
        public string visitorName { get; set; }=String.Empty;

        public string parentRelation { get; set; }= String.Empty;
    }
}
