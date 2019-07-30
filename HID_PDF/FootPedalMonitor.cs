using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;

namespace HID_PDF
{

    public class FootPedalMonitor : IInputMonitor
    {
        private HidDevice HIDDevice;
        private HidStream HIDStream;
        private Boolean HIDStreamOpen;
        public delegate void HIDDeviceRead(object device, EventArgs e);
        public HIDDeviceRead OnHIDDeviceRead;

        public event EventHandler StreamClosed;

        public void Setup(String DeviceName)
        {
            var localList = DeviceList.Local;
            StreamClosed = OnStreamClosed;
            HIDStreamOpen = false;
            IEnumerable<Device> attachedDevices = localList.GetAllDevices();
            Console.WriteLine(attachedDevices.Count<Device>() + " found");
            foreach (Device device in attachedDevices)
            {
                Console.WriteLine("Device: " + device.GetFriendlyName());
            }
            IEnumerable<HidDevice> attachedHidDevices = localList.GetHidDevices();
            Console.WriteLine(attachedHidDevices.Count<Device>() + " HID found");
            foreach (HidDevice device in attachedHidDevices)
            {
                if (device.GetFriendlyName().ToLower().Equals(DeviceName.ToLower()))
                {
                    HIDDevice = device;
                    HIDStream = HIDDevice.Open();
                    HIDStream.Closed += this.StreamClosed;
                    HIDStreamOpen = (HIDStream != null);
                }
            }
        }

        public void Read()
        {
            byte[] mouseBuffer = new byte[128];
            while (HIDStreamOpen)
            {
                //HIDStream.BeginRead(mouseBuffer, 0, 128, null, null);
                try
                {
                    mouseBuffer = HIDStream.Read();
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    Console.WriteLine("What was read: " + whatRead);
                    // Call the callback function
                    if (OnHIDDeviceRead != null)
                    {
                        OnHIDDeviceRead(this, EventArgs.Empty);
                    }
                }
                catch (TimeoutException t)
                {
                    Console.WriteLine("Timeout: " + t.Message);
                }
            }
        }

        protected virtual void OnStreamClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Stream closed.");
            HIDStreamOpen = false;
        }
    }
}