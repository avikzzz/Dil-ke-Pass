using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Commands.CreateTourAttractions
{
    public class CreateTourAttractionCommand
    {
        public string PlaceName { get; set; }
        public string Address { get; set; }

        public string State  { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public string? Comments { get; set; }
        public int NumberOfDaysOpen { get; set; }
        public string? DayClosed { get; set; }
        public string CreatedBy { get; set; }
    }

}
