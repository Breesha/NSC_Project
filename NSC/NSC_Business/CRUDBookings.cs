using System;
using NSC_Model;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NSC_Business
{
    public class CRUDBookings
    {
        public Booking SelectBooking { get; set; }

        public List<Booking> AllBooking()
        {
            using (var db = new NSCContext())
            {
                return db.Bookings.ToList();
            }
        }

        public void CreateBooking(int memberId, int roomId, int sportId, DateTime datePicked, TimeSpan timePicked)
        {
            using (var db = new NSCContext())
            {
                var newBooking = new Booking
                {
                    MemberId = memberId,
                    RoomId = roomId,
                    SportId = sportId,
                    DateNeeded = datePicked,
                    TimeSlot = timePicked
                };

                db.Bookings.Add(newBooking);
                db.SaveChanges();
            }
        }
    }
}
