using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Visitors.Commands.AddVisitors
{
    public class AddVisitorsCommand
    {
        public int userId { get; set; }
        public string touristName { get; set;} = String.Empty;

        public DateTime dob { get; set;}
        public char Gender { get; set;}
        public string ParentRelation { get; set;}= String.Empty;

    }
}
