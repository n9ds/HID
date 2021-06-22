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
        public Boolean HIDStreamOpen { get; set; }
        public Boolean DeviceFound { get; set; }
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
            XmlNode node = doc.SelectSingleNode("/devices/device[systemname = \"" + DeviceName + "\"]");
            if (node != null)
            {
                ConfigMessages(node.SelectNodes("./messages"));
                Setup();
            }
            else
            {
                throw (new NotImplementedException(DeviceName + " has not been configured for use with this program."));
            }
        }

        public void Setup()
        {
            HidDevice device = FindDevice(DeviceName);
            if (device == null)
            {
                DeviceFound = false;
                HIDStreamOpen = false;
                HIDDevice = null;
            }
            else
            {
                DeviceFound = true;
                HIDStreamOpen = false;
                HIDDevice = device;
                if (HIDDevice.TryOpen(out HIDStream))
                {
                    HIDStream.Closed += this.OnStreamClosed;
                    HIDStreamOpen = (HIDStream != null);
                }
            }
            return;
        }

        private HidDevice FindDevice(String DeviceName)
        {
            var device = DeviceList.Local.GetHidDevices().Where(d => d.GetFriendlyName().Equals(DeviceName)).FirstOrDefault();
            if (device != null)
            {
                Console.WriteLine(DeviceName + " found");
            }
            else
            {
                Console.WriteLine("Could not find " + DeviceName);
            }
            return (device);
        }

        private void ConfigMessages(XmlNodeList nodes)
        {
            MessageTable = new Dictionary<String, String>();
            // TODO: Make sure the messages for the specific device
            XmlNodeList xmlMessages = nodes.Item(0).SelectNodes("./message");
            foreach (XmlNode node in xmlMessages)
            {
                MessageTable.Add(node.SelectSingleNode("messagevalue").InnerText, node.SelectSingleNode("messageevent").InnerText);
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
                    Console.WriteLine(DeviceName + " read: " + whatRead);
                    SendMessage(whatRead);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (TimeoutException t)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    // A timeout is not necessarily a problem.  We don't want to blindly sit and wait for data that may never come, but 
                    // some devices don't send any data unless there's a button pressed.
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
            Console.WriteLine(DeviceName + " Stream closed.");
            HIDStream.Closed -= this.OnStreamClosed;
            HIDStreamOpen = false;
        }
    }

    #region "Obsolete or Otherwise Unused"
    //IEnumerable<HidDevice> attachedHidDevices = DeviceList.Local.GetHidDevices();
    //var device = attachedHidDevices.Where(d => d.GetFriendlyName().Equals(DeviceName)).FirstOrDefault();
    //
    //
    //var localList = DeviceList.Local;
    //IEnumerable<HidDevice> attachedHidDevices = localList.GetHidDevices();
    //IEnumerable<Device> attachedDevices = localList.GetAllDevices();
    //Console.WriteLine(attachedDevices.Count<Device>() + " found");
    //foreach (Device device in attachedDevices)
    //{
    //    Console.WriteLine("Device: " + device.GetFriendlyName());
    //}
    //foreach (HidDevice device in attachedHidDevices)
    //{
    //    if (device.GetFriendlyName().ToLower().Equals(DeviceName.ToLower()))
    //    {
    //        return (device);
    //    }
    //}
    //return (null);
    #endregion
}