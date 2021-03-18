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

        public void ChosenBooking(object selectedBooking)
        {
            SelectBooking = (Booking)selectedBooking;
        }


        public List<int> AllRooms_ID()
        {
            List<int> roomid = new List<int> { 1, 2, 3, 4, 5, 6 };
            return roomid;

            //using (var db = new NSCContext())
            //{
            //    return db.Rooms.ToList();
            //}
        }


        public List<int> AllSports_ID()
        {
            List<int> sportid = new List<int> { 1, 2, 3, 4, 5, 6,7,8,9,10,11,12,13 };
            return sportid;
        }

        public Sport SpecSport_ID(int? id)
        {
            using (var db = new NSCContext())
            {
                Sport
                                        //sport = "1 - Platform Diving";
                                        sport = id switch
                                        {
                                            1 => db.Sports.Where(e => e.SportId == 1).FirstOrDefault(),//sport = "1 - Platform Diving";
                                            2 => db.Sports.Where(e => e.SportId == 2).FirstOrDefault(),
                                            3 => db.Sports.Where(e => e.SportId == 3).FirstOrDefault(),
                                            4 => db.Sports.Where(e => e.SportId == 4).FirstOrDefault(),
                                            5 => db.Sports.Where(e => e.SportId == 5).FirstOrDefault(),
                                            6 => db.Sports.Where(e => e.SportId == 6).FirstOrDefault(),
                                            7 => db.Sports.Where(e => e.SportId == 7).FirstOrDefault(),
                                            8 => db.Sports.Where(e => e.SportId == 8).FirstOrDefault(),
                                            9 => db.Sports.Where(e => e.SportId == 9).FirstOrDefault(),
                                            10 => db.Sports.Where(e => e.SportId == 10).FirstOrDefault(),
                                            11 => db.Sports.Where(e => e.SportId == 11).FirstOrDefault(),
                                            12 => db.Sports.Where(e => e.SportId == 12).FirstOrDefault(),
                                            13 => db.Sports.Where(e => e.SportId == 13).FirstOrDefault(),
                                            _ => db.Sports.Where(e => e.SportId == 1).FirstOrDefault(),
                                        };
                return sport;
            }
        }

        public List<Sport> AllSports()
        {
            using (var db = new NSCContext())
            {
                return db.Sports.ToList();
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
