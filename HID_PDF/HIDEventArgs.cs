using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF
{
    public class HIDEventArgs : EventArgs
    {
        public String Message { get; set; }

        public HIDEventArgs() : base()
        {

        }

        public HIDEventArgs(string message)
        {
            Message = message;
        }
    }
}
