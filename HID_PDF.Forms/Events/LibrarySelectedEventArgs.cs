using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF.Forms
{
    public class LibrarySelectedEventArgs : EventArgs
    {
        public int LibraryId { get; set; }
        public String LibraryName { get; set; }
        public int Mode { get; set; }
    }
}
