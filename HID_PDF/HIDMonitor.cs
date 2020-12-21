using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using HidSharp;

namespace HID_PDF
{

    public class HIDMonitor : IInputMonitor
    {
        private HidDevice HIDDevice;
        private HidStream HIDStream;
        public Boolean HIDStreamOpen;
        public Boolean DeviceFound;
        // 12/18/2020
        //public delegate void HidDeviceRead(object device, HIDEventArgs e);
        //public event HidDeviceRead OnHidDeviceRead;
        // End 12/18/2020
        public event EventHandler<HIDEventArgs> OnHidDeviceRead;
        public IDictionary<String, String> MessageTable;

        public String ConfigFile { get; set; }
        public String DeviceName { get; set; }

        public void Config()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigFile);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/devices/device");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("System name: " + node.SelectSingleNode("systemname").InnerText);
                if (node.SelectSingleNode("systemname").InnerText.Equals(DeviceName))
                {
                    ConfigMessages(node.SelectNodes("./messages"));
                    Setup();
                }
            }
        }

        public void Setup()
        {
            DeviceFound = false;
            HidDevice device = FindDevice(DeviceName);
            if (device == null)
            {
                DeviceFound = false;
                return;
            }
            DeviceFound = true;
            HIDStreamOpen = false;
            HIDDevice = device;
            if (HIDDevice.TryOpen(out HIDStream))
            {
                HIDStream.Closed += this.OnStreamClosed;
                HIDStreamOpen = (HIDStream != null);
            }
        }

        public IList<String> ListDevices()
        {
            var localList = DeviceList.Local;
            var Devices = new List<String>();
            IEnumerable<Device> attachedDevices = localList.GetAllDevices();
            Console.WriteLine(attachedDevices.Count<Device>() + " found");
            foreach (Device device in attachedDevices)
            {
                Devices.Add(device.GetFriendlyName());
            }
            return (Devices);
        }

        private HidDevice FindDevice(String DeviceName)
        {
            var localList = DeviceList.Local;
            //IEnumerable<Device> attachedDevices = localList.GetAllDevices();
            //Console.WriteLine(attachedDevices.Count<Device>() + " found");
            //foreach (Device device in attachedDevices)
            //{
            //    Console.WriteLine("Device: " + device.GetFriendlyName());
            //}
            IEnumerable<HidDevice> attachedHidDevices = localList.GetHidDevices();
            Console.WriteLine(attachedHidDevices.Count<Device>() + " HID found");
            foreach (HidDevice device in attachedHidDevices)
            {
                if (device.GetFriendlyName().ToLower().Equals(DeviceName.ToLower()))
                {
                    return (device);
                }
            }
            return (null);
        }

        public void ConfigMessages(XmlNodeList nodes)
        {
            MessageTable = new Dictionary<String, String>();
            XmlNodeList xmlMessages = nodes.Item(0).SelectNodes("./message");
            foreach (XmlNode node in xmlMessages)
            {
                MessageTable.Add(node.SelectSingleNode("messagevalue").InnerText, node.SelectSingleNode("messageevent").InnerText);
            }
        }

        public void Read()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            byte[] mouseBuffer = new byte[128];
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            while (HIDStreamOpen)
            {
                try
                {
                    mouseBuffer = HIDStream.Read();
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    Console.WriteLine("What was read: " + whatRead);
                    SendMessage(whatRead);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (TimeoutException t)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    // Console.WriteLine("Timeout: " + t.Message);                   
                    Console.WriteLine("*");
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
            }
        }

        public void SendMessage(String message)
        {
            Console.WriteLine("(Test) What was read: " + message);
            // Call the callback function
            if (MessageTable.TryGetValue(message, out String eventMessage) && OnHidDeviceRead != null)
            {
                // Send the message here. 
                OnHidDeviceRead(this, new HIDEventArgs(eventMessage));
            }
        }

        protected virtual void OnStreamClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Stream closed.");
            HIDStream.Closed -= this.OnStreamClosed;
            HIDStreamOpen = false;
        }
    }
}