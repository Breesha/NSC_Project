using System;
using System.Collections.Generic;

#nullable disable

namespace NSC_Model
{
    public partial class staff
    {
        public staff()
        {
            Sports = new HashSet<Sport>();
        }

        public int StaffId { get; set; }
        public string StaffName { get; set; }

        public virtual ICollection<Sport> Sports { get; set; }
    }
}
