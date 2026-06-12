using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Commands.CreatePrice
{
    public class CreatePriceCommand
    {
        public int PlaceId {  get; set; }
        public string VisitorType { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
