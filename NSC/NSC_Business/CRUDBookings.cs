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

        public void UpdateBooking(int bookingid, int roomId, int sportId, DateTime datePicked, TimeSpan timePicked)
        {
            using (var db = new NSCContext())
            {
                SelectBooking = db.Bookings.Where(c => c.BookingId == bookingid).FirstOrDefault();
                //setSelectedRider(email);
                SelectBooking.RoomId = roomId;
                SelectBooking.SportId = sportId;
                SelectBooking.DateNeeded = datePicked;
                SelectBooking.TimeSlot = timePicked;

                db.SaveChanges();
            }
        }

        public void DeleteBooking(int bookingId)
        {
            using (var db = new NSCContext())
            {
                   var selectedBooking =
                   from b in db.Bookings
                   where b.BookingId == bookingId
                   select b;
                   db.Bookings.RemoveRange(selectedBooking);
                   db.SaveChanges();
            }
        }
    }
}
