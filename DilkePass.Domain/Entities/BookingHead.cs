using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class BookingHead : Entity<int>, IAudit
    {
        public int UserId { get; private set; }
        public int PlaceId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public char BookingStatus { get; private set; }
        public char PayMentStatus { get; private set; } = 'N';
        public char ApprovalStatus { get; private set; }
        public string? ApprovedBy { get; private set; } //confusion
        public DateTime? ApprovalDate { get; private set; }
        public DateOnly VisitDate { get; private set; }
        public TimeOnly? VisitTime { get; private set; }
        public DateTime? PaymentDueTime { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }

        //navigation property. // etao ekta property
        //ei class er e property jeta onno karur sathe relation korte kaaje laage

        public User? User { get; set; }
        public TourAttractions? Place { get; set; }


        // as an agreegate root of BookingLine

        // ei line tar maane : Readonly --> cause _bookiLine e ar kono notun object list assign kora jaabe naa.
        // Means: _bookingLine = new List<BookingLine>() --> eta not allowed
        // Eta private, jaate eta baire theke change naa kora jae. Add, update, delete eisob readonly te allowed.
        private readonly List<BookingLine> _bookingLine = new();

        // Ebar problem is, bairer lokera ki Lines dekhbei naa ?
        // Eta public jaate baire dekha jae
        // IReadonlyCollection instead of List<>, jaate sudhu dekha jae, no modification. Remember readonly te data kintu modify hoe
        // Eta kintu ekta property, method noe 
        public IReadOnlyCollection<BookingLine> bookingLine
        {
            get
            {
                return _bookingLine;
            }
        }



        // ebar implementation. BookingLine shudhu ekhan thekei jaate edit kora jae.

        //dara, first e constructors
        private BookingHead() { } // EF Core er naaki lagbe .. janina

        //Eta use hobe jokhon bookingHead create korbo.
        // Means, jokhon e ei class ta ke call korbe, ei data lagbei...
        // Ki labh ? Erokom kono booking create e hobe naa, jeta te user achhe, place nei, othoba, sob achhe date ta default and hijibiji
        // COns
        public BookingHead(int userId, int placeId, DateOnly visitDate)
        {
            this.UserId= userId;
            this.PlaceId= placeId;
            this.VisitDate = visitDate;
                
        }

        // logic for booking Line
        public void AddBookingLine(int touristId, string touristName, DateOnly dob, char gender, string typeCode, decimal unitPrice, decimal taxPercent, decimal serviceChargePercent )
        {
            int lineNo = _bookingLine.Count + 1; 

            var line = new BookingLine(
                Id,                           // Entity
                lineNo,
                touristId,
                touristName,
                dob,
                gender,
                typeCode,
                unitPrice,
                taxPercent,
                serviceChargePercent
            );

            _bookingLine.Add(line);
            TotalAmount += line.LineTotal;



            
        }
    }
}
