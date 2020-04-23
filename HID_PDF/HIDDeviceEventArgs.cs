using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF
{
    class HIDDeviceEventArgs : EventArgs
    {
        public String DeviceName { get; set; }
        public String Message { get; set; }
   public HIDDeviceEventArgs(String message)
    {
        this.Message = message;
    }
    }
}
