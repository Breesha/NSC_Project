using NUnit.Framework;
using System.Linq;
using NSC_Model;
using NSC_Business;
using System;

namespace NSC_Tests
{
    public class MemberTests
    {
        CRUDMembers _crudMembers = new CRUDMembers();

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new NSCContext())
            {
                var selectedMember =
                from m in db.Members
                where m.Username == "stephfoxton"
                select m;
                db.Members.RemoveRange(selectedMember);
                db.SaveChanges();
            }
        }

        [Test]
        public void CREATEMember_NumberIncreasesBy1()
        {
            using (var db = new NSCContext())
            {
                var numberBefore = db.Members.ToList().Count();
                _crudMembers.CreateMember("stephfoxton", "Password");
                var numberAfter = db.Members.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }
        }

        [Test]
        public void READMemberAdded_CorrectDetails()
        {
            using (var db = new NSCContext())
            {
                var numberBefore = db.Members.ToList().Count();
                _crudMembers.CreateMember("stephfoxton", "Password");
                var numberAfter = db.Members.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);

                var createdMember =
                    from m in db.Members
                    where m.Username == "stephfoxton"
                    select m;

                foreach (var c in createdMember)
                {
                    Assert.AreEqual("Password", c.Passwrd);
                    //Assert.AreEqual(1, c.MemberId);
                }
            }
        }

        [Test]
        public void DELETEMember_NumberDecreasesBy1()
        {
            using (var db = new NSCContext())
            {
                var newMember = new Member
                {
                    Username = "stephfoxton",
                    Passwrd = "Password"
                };
                db.Members.Add(newMember);
                db.SaveChanges();
                var numberBefore = db.Members.ToList().Count();

                _crudMembers.DeleteMember("stephfoxton", "Password");
                var numberAfter = db.Members.ToList().Count();

                Assert.AreEqual(numberBefore, numberAfter + 1);
            }
        }
    }





    public class BookingTests
    {
        CRUDBookings _crudBookings = new CRUDBookings();

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new NSCContext())
            {
                var selectedBookings =
                from b in db.Bookings
                where b.MemberId == 1 && b.RoomId==2
                select b;
                db.Bookings.RemoveRange(selectedBookings);
                db.SaveChanges();
            }
        }

        [Test]
        public void CREATEBooking_NumberIncreasesBy1()
        {
            using (var db = new NSCContext())
            {
                var numberBefore = db.Bookings.ToList().Count();
                _crudBookings.CreateBooking(1, 2, 4, DateTime.Now, TimeSpan.FromHours(1.00));
                var numberAfter = db.Bookings.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);
            }
        }

        [Test]
        public void READBookingAdded_CorrectDetails()
        {
            using (var db = new NSCContext())
            {
                var numberBefore = db.Bookings.ToList().Count();
                _crudBookings.CreateBooking(1, 2, 4, Convert.ToDateTime("10/03/2021"), TimeSpan.FromHours(1.00));
                var numberAfter = db.Bookings.ToList().Count();

                Assert.AreEqual(numberBefore + 1, numberAfter);

                var createdBooking =
                    from b in db.Bookings
                    where b.MemberId == 1 && b.RoomId==2
                    select b;

                foreach (var c in createdBooking)
                {
                    Assert.AreEqual(2, c.RoomId);
                    Assert.AreEqual(4, c.SportId);
                    Assert.AreEqual(Convert.ToDateTime("10/03/2021"), c.DateNeeded);
                    Assert.AreEqual(TimeSpan.FromHours(1.00), c.TimeSlot);
                }
            }
        }

        [Test]
        public void UPDATEBookingDetails_DatabaseIsUpdated()
        {
            _crudBookings.UpdateBooking(8, 4, 9, Convert.ToDateTime("11/04/2021"), TimeSpan.FromHours(1.00));

            using (var db = new NSCContext())
            {
                var SelectedBooking = db.Bookings.Where(c => c.BookingId == 8).FirstOrDefault();

                Assert.AreEqual(4, SelectedBooking.RoomId);
                Assert.AreEqual(9, SelectedBooking.SportId);
                Assert.AreEqual(Convert.ToDateTime("11/04/2021"), SelectedBooking.DateNeeded);
                Assert.AreEqual(TimeSpan.FromHours(1.00), SelectedBooking.TimeSlot);
            }
        }
    }
}