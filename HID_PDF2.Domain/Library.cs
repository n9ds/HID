using System;
using System.Collections.Generic;
using System.Text;

namespace HID_PDF.Domain
{
    public class Library
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
