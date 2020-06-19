using System;
using System.Collections.Generic;
using System.Text;

namespace HID_PDF.Domain
{
    public class SetlistEntry
    {
        public int Id { get; set; }
        public Song Song { get; set; }
        public int SetOrder { get; set; }

        public SetlistEntry()
        {
            Song = null;
            SetOrder = -1;
        }
        public SetlistEntry(Song song, int setOrder)
        {
            Song = song;
            SetOrder = setOrder;
        }
    }
}
