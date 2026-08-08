using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Visitors.DTOs
{
    public class GetvisitorDetailsResponse
    {
        public int VisitorId { get; set; }
        public int UserId { get; set; }
        public string TouristName { get;  set; } = string.Empty;
        public DateTime TouristDOB { get; set; }
        public char Gender { get; set; }
        public string? ParentRelation { get;  set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
