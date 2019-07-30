using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;

namespace HID
{
    class Program
    {
        static void Main(string[] args)
        {
            var localList = DeviceList.Local;
            HidStream inData;
            byte[] mouseBuffer = new byte[128];
            //localList.
            DeviceList deviceList = new FilteredDeviceList();
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
                Console.WriteLine("Device: " + device.GetFriendlyName());
                if (device.GetFriendlyName().ToLower().Contains("mifi"))
                {
                    inData = device.Open();
                    inData.BeginRead(mouseBuffer, 0, 128, null, null);
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    Console.WriteLine("What was read: " + whatRead);
                }
            }
        }
    }
}
