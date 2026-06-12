using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.DTOs
{
    public class GetTouristPlacesByStateResponse
    {
        public int Id { get; set; }
        public string PlaceName { get;  set; } = string.Empty;
        public string Address { get;  set; } = string.Empty;
        public string State { get;  set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public string Comments { get; set; } = string.Empty;

        public int? NumberOfDaysOpen { get; set; }
        public string DayClosed { get; set; } = string.Empty;
    

    }
}
