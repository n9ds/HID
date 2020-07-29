using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF.Forms
{
    public class SongSelectedEventArgs : EventArgs
    {
        public int SongId { get; set; }
        public String Filename { get; set; }
        public int Mode { get; set; }
    }
}
