using System;
using System.Collections.Generic;
using System.Text;

namespace HID_PDF.Domain
{
    public class Setlist
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Band { get; set; }
        public virtual ICollection<SetlistEntry> SetlistEntries { get; set; }
    }
}
