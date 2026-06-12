using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class BookingLine:Entity<int>
    {
        public int BookingId { get; private set; }

        public int LineNo { get; private set; }

        public int? TouristId { get; private set; }

        public string TouristName { get; private set; } = string.Empty;

        public DateOnly DateOfBirth { get; private set; }

        public char Gender { get; private set; }

        public string TouristTypeCode { get; private set; } = string.Empty;

        public decimal UnitPrice { get; private set; }

        public decimal TaxPercent { get; private set; }

        public decimal TaxAmount { get; private set; }

        public decimal ServiceChargePercent { get; private set; }

        public decimal ServiceChargeAmount { get; private set; }

        public decimal LineTotal { get; private set; }

        public string LineStatus { get; private set; } = string.Empty;
        public DateTime? CreatedDate { get; private set; }

        public BookingLine()
        {
                
        }
        internal BookingLine(int bookingId,int lineNo, int touristId,string touristName, 
            DateOnly dob, char gender, string touristTypeCode, decimal unitPrice,
            decimal taxPercent,decimal serviceChargePercent)
        {
            BookingId = bookingId;
            LineNo = lineNo;
            TouristId = touristId;
            TouristName = touristName;
            DateOfBirth = dob;
            Gender = gender;
            TouristTypeCode = touristTypeCode;
            UnitPrice = unitPrice;
            TaxPercent = taxPercent;
            ServiceChargePercent = serviceChargePercent;
            LineTotal = UnitPrice + TaxAmount+ServiceChargeAmount;
            LineStatus = "A";
            TaxAmount = UnitPrice * taxPercent / 100;
            ServiceChargeAmount = UnitPrice * ServiceChargePercent / 100;
        }
    }
}
