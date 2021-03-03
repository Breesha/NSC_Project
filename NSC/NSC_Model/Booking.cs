using System;
using System.Collections.Generic;

#nullable disable

namespace NSC_Model
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? MemberId { get; set; }
        public int? RoomId { get; set; }
        public int? SportId { get; set; }
        public DateTime DateNeeded { get; set; }
        public TimeSpan TimeSlot { get; set; }

        public virtual Member Member { get; set; }
        public virtual Room Room { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
