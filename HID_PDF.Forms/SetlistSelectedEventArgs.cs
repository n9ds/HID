using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF.Forms
{
    public class SetlistSelectedEventArgs : EventArgs
    {
        public int SetlistId { get; set; }
        public String SetlistName { get; set; }
        public int BandId { get; set; }
        public int Mode { get; set; }
    }
}
