using System;
using System.Collections.Generic;

#nullable disable

namespace NSC_Model
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
