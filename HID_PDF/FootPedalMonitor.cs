using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using HidSharp;

namespace HID_PDF
{

    public class FootPedalMonitor : IInputMonitor
    {
        private HidDevice HIDDevice;
        private HidStream HIDStream;
        public Boolean HIDStreamOpen;
        public Boolean DeviceFound;
        public delegate void HidDeviceRead(object device, HIDEventArgs e);
        public event HidDeviceRead OnHidDeviceRead;
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
            byte[] mouseBuffer = new byte[128];
            while (HIDStreamOpen)
            {
                try
                {
                    mouseBuffer = HIDStream.Read();
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    Console.WriteLine("What was read: " + whatRead);
                    SendMessage(whatRead);
                }
                catch (TimeoutException t)
                {
                    Console.WriteLine("Timeout: " + t.Message);
                }
            }
        }

        public void SendMessage(String message)
        {
            Console.WriteLine("(Test) What was read: " + message);
            // Call the callback function
            String eventMessage;
            if (MessageTable.TryGetValue(message, out eventMessage))
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