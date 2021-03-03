using System;
using NSC_Model;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NSC_Business
{
    public class CRUDMembers
    {
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
    }
}
