using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF
{
    interface IInputMonitor
    {
        void Setup(String DeviceName);
        void Read();
    }
}
