using System;
using System.Collections.Generic;

#nullable disable

namespace NSC_Model
{
    public partial class Sport
    {
        public Sport()
        {
            Bookings = new HashSet<Booking>();
        }

        public int SportId { get; set; }
        public string SportName { get; set; }
        public int? StaffId { get; set; }

        public virtual staff Staff { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
