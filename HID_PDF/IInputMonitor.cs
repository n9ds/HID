using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF
{
    interface IInputMonitor
    {
        void Config();
        void Setup();
        void Read();
    }
}
