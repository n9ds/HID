using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF.CustomExceptions
{
    public class DeviceNotFoundException : Exception
    {
        public String DeviceName { get; set; }

        public DeviceNotFoundException(String Message) : base(Message)
        {
        }

        public DeviceNotFoundException(String Message, String DeviceName) : base(Message)
        {
            this.DeviceName = DeviceName;
        }
    }
}
