using System;

namespace HID_PDF.Domain
{
    public class Song
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Artist { get; set; }
        public String Instrument { get; set; }
        public String Key { get; set; }
        public bool Major { get; set; }
        public String FirstNote { get; set; }
        public String Filepath { get; set; }
        public String Filetype { get; set; }
    }
}
