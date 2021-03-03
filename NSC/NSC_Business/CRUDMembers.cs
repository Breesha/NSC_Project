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

        public List<Member> AllMember()
        {
            using (var db = new NSCContext())
            {
                return db.Members.ToList();
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
