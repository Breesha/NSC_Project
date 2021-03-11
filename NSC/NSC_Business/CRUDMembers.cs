using System;
using NSC_Model;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NSC_Business
{
    public class CRUDMembers
    {
        static void Main(string[] args)
        {
            using (var db = new NSCContext())
            {

            }
        }

        public Member SelectMember { get; set; }

        public void ChooseMember(string username)
        {
            using (var db = new NSCContext())
            {
                SelectMember = db.Members.Where(e => e.Username.Trim() == username.Trim()).FirstOrDefault();
            }
        }

        public List<Booking> MemberBookings(string username)
        {
            using (var db = new NSCContext())
            {
                return (from b in db.Bookings
                        join m in db.Members on b.MemberId equals m.MemberId
                        where m.Username == username
                        select b).ToList();
            }
        }

        public void CreateMember(string username, string password)
        {
            using (var db = new NSCContext())
            {
                var newMember = new Member
                {
                    Username = username.Trim(),
                    Passwrd = password.Trim()
                };

                db.Members.Add(newMember);
                db.SaveChanges();
            }
        }

        public void DeleteMember(string username, string password)
        {
            using (var db = new NSCContext())
            {
                var selectedMemberBookings = 
                    from b in db.Bookings
                    join m in db.Members on b.MemberId equals m.MemberId
                    where m.Username == username && m.Passwrd == password
                    select b;
                db.Bookings.RemoveRange(selectedMemberBookings);
                db.SaveChanges();

                var selectedMember =
                    from m in db.Members
                    where m.Username == username && m.Passwrd == password
                    select m;
                db.Members.RemoveRange(selectedMember);
                db.SaveChanges();
            }
        }
    }
}
