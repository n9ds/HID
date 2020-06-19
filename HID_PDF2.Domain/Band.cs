using System;
using System.Collections.Generic;
using System.Text;

namespace HID_PDF.Domain
{
    public class Band
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Setlist> Setlists { get; set; }

        public override String ToString()
        {
            return (Name);
        }
    }
}
