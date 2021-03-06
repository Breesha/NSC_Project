﻿using System;

namespace NSC_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NSCContext())
            {
                var newBooking1 = new Booking()
                {
                    MemberId = 1,
                    RoomId = 3,
                    SportId = 7,
                    DateNeeded = Convert.ToDateTime("15/03/2021"),
                    TimeSlot = TimeSpan.FromHours(2.00)
                };
                db.Bookings.Add(newBooking1);
                db.SaveChanges();

            }
        }

    }
}
