using System;
using System.Collections.Generic;

#nullable disable

namespace NSC_Model
{
    public partial class Member
    {
        public Member()
        {
            Bookings = new HashSet<Booking>();
        }

        public int MemberId { get; set; }
        public string Username { get; set; }
        public string Passwrd { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
