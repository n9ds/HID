using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;
using System.Xml;

namespace HID
{
    class Program
    {
        private static void Config(String devicename)
        {
            XmlDocument doc = new XmlDocument();
            String ConfigFile = "deviceconfig.xml";
            doc.Load(ConfigFile);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/devices/device");
            // Add systemname to the query
            // /devices/device[systemname = "VEC USB Footpedal"]
            XmlNode device = doc.SelectSingleNode("/devices/device[systemname = \"" + devicename + "\"]");
            if (device != null)
            {
                Console.WriteLine("Found " + device.InnerText);
            }
            //foreach (XmlNode node in nodes)
            //{
            //    Console.WriteLine("System name: " + node.SelectSingleNode("systemname").InnerText);
            //    if (node.SelectSingleNode("systemname").InnerText.Equals("VEC USB Footpedal"))
            //    {
            //        Console.WriteLine("Found");
            //    }
            //}

        }
        static void Main(string[] args)
        {
            var parser = new HidParse();
            parser.SetIdleMessage("00-00-00");
            parser.LoadMessageTable();
            parser.Parse("00-02-00");
            parser.Parse("00-33-00");
            var dx = parser.ComputeDifferences("00-01-00");
            var localList = DeviceList.Local;
            byte[] mouseBuffer = new byte[128];
            IEnumerable<Device> attachedDevices = localList.GetAllDevices();
            Console.WriteLine(attachedDevices.Count<Device>() + " found");
            
            foreach (Device device in attachedDevices)
            {
                Console.WriteLine(device.GetFriendlyName());
            }
            IEnumerable<HidDevice> attachedHidDevices = localList.GetHidDevices();
            Console.WriteLine(attachedHidDevices.Count<Device>() + " HID found");
            HidStream HIDStream;
            int i;
            var SelectedDevice = DeviceList.Local.GetHidDevices().Where(d => d.GetFriendlyName().ToLower().Contains("vec")).FirstOrDefault();
            SelectedDevice.TryOpen(out HIDStream);

            for (i = 1; i < 30000; i++)
            {
                //mouseBuffer = HIDStream.Read();
                //string whatRead = BitConverter.ToString(mouseBuffer);
                //Console.WriteLine("What was read: " + whatRead);
                try
                {
                    mouseBuffer = HIDStream.Read();
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    Console.WriteLine(" read: " + whatRead);
                    //SendMessage(whatRead);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (TimeoutException t)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    // A timeout is not necessarily a problem.  We don't want to blindly sit and wait for data that may never come, but 
                    // some devices don't send any data unless there's a button pressed.
                    Console.WriteLine("*");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                System.Windows.Forms.SendKeys.SendWait("Hello");
            }
        }

        //foreach (HidDevice device in attachedHidDevices)
        //{
        //    Console.WriteLine("Device: " + device.GetFriendlyName() + " (" + device.GetFileSystemName() + ")");
        //    if (device.GetFriendlyName().ToLower().Contains(DeviceName))
        //    {
        //        //HidSharp.Reports.ReportDescriptor r = device.GetReportDescriptor();
        //        HidStream HIDStream;
        //        int i;
        //        device.TryOpen(out HIDStream);

        //        for (i = 1; i < 30000; i++)
        //        {
        //            mouseBuffer = HIDStream.Read();
        //            string whatRead = BitConverter.ToString(mouseBuffer);
        //            Console.WriteLine("What was read: " + whatRead);
        //        }
        //    }
        }
}
