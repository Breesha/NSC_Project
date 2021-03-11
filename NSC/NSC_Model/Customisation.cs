using System;
using System.Collections.Generic;
using System.Text;

namespace NSC_Model
{
    public partial class Booking
    {
        public override string ToString()
        {
            return $"Booking {BookingId} - Date {DateNeeded.Day}/{DateNeeded.Month}/{DateNeeded.Year}";
        }
    }

    public partial class Room
    {
        public override string ToString()
        {
            return $"{RoomId} - {RoomName}";
        }
    }

    public partial class Sport
    {
        public override string ToString()
        {
            return $"{SportId} - {SportName}";
        }
    }
}
