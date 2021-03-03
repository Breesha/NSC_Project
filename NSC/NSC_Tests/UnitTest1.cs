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

                Assert.AreEqual(numberBefore, numberAfter +1);
            }
        }
    }
}