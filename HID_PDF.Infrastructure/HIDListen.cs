using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;

namespace HID_PDF.Infrastructure
{
    // This class is only used during Configuration.  It will open a device and listen for a message.
    // Listen for a change and report it.
    // Timeout is short enough that we can just call it synchronously.
    public class HIDListen
    {
        private HidDevice HIDDevice;
        private HidStream HIDStream;
        private HIDMessage HIDMessage;
        private String IdleMessage;

        public String DeviceName { get; set; }
        public bool WatchForChange { get; set; }
        public bool HIDStreamOpen { get; set; }
        public bool DeviceFound { get; set; }
        public bool Enabled { get; set; }

        public void Config()
        {
            throw (new NotImplementedException());
        }

        public void Setup()
        {
            Setup(this.DeviceName);
        }

        public void Setup(String DeviceName)
        {
            this.DeviceName = DeviceName;
            DeviceFound = false;
            HidDevice device = FindDevice(DeviceName);
            if (device == null)
            {
                DeviceFound = false;
                return;
            }
            DeviceFound = true;
            HIDMessage = new HIDMessage();
            HIDStreamOpen = false;
            HIDDevice = device;
            if (HIDDevice.TryOpen(out HIDStream))
            {
                HIDStream.Closed += this.OnStreamClosed;
                HIDStreamOpen = (HIDStream != null);
            }
            IdleMessage = CheckIdle();  // Do a read.  If it times out, then return will be "" and we know we can just read the value
                                        // and report it.  If it does not time out, return will be a string, and we know we need to wait
                                        // for some sort of change and do some processing with the HIDMessage object.
                                        // If the return comes back null then something wacky happened.
            if (IdleMessage == null)
            {
                throw (new ApplicationException("A error occurred reading the device, but the error did not cause an exception."));
            }
            WatchForChange = !String.IsNullOrEmpty(IdleMessage);
        }

        private HidDevice FindDevice(String DeviceName)
        {
            var localList = DeviceList.Local;
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

        // Read.  If a value is returned before timeout then we know this is a streaming device, and we need to watch
        // for changes, otherwise just return what got read.
        // 
        private String CheckIdle()
        {
            byte[] mouseBuffer = new byte[128];
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            while (HIDStreamOpen)
            {
                try
                {
                    mouseBuffer = HIDStream.Read();
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    return (whatRead);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (TimeoutException t)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    return (String.Empty);
                }
                catch (Exception e)
                {
                    throw (new ApplicationException("Error while listening: " + e.Message));
                }
            }
            return (null);  // We should never get to this point, but if we do, the calling routine should know about it.
        }

        public HIDMessage Read()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            byte[] mouseBuffer = new byte[128];
            var message = new HIDMessage();
            HIDMessage computedMessage = null;
            String previousRead = IdleMessage;

#pragma warning restore IDE0059 // Unnecessary assignment of a value
            while (HIDStreamOpen)
            {
                try
                {
                    mouseBuffer = HIDStream.Read();
                    string whatRead = BitConverter.ToString(mouseBuffer);
                    Console.WriteLine("What was read: " + whatRead);
                    // If we're waiting for a change and a change happened, or we aren't waiting for a change, then sent the message.
                    if (!WatchForChange)
                    {
                        message.IsBinary = true;
                        message.RawMessage = whatRead;
                        computedMessage = message;
                        break;
                    }
                    else
                    {
                        // If what we just read is what we read before and both are idle, then keep reading.
                        if (whatRead.Equals(previousRead) && whatRead.Equals(IdleMessage))
                        {
                            continue;
                        }
                        // We read something, but it's not back to idle yet, add it to the list of things we've read so far, 
                        // but keep reading.
                        if (!whatRead.Equals(previousRead) && !whatRead.Equals(IdleMessage))
                        {
                            message.AddMessage(whatRead);
                            previousRead = whatRead;
                            continue;
                        }
                        // We're back to idle, so we have our answer.
                        if (!whatRead.Equals(previousRead) && whatRead.Equals(IdleMessage))
                        {
                            computedMessage = message.ComputeMessage();
                            break;
                        }
                    }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (TimeoutException t)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    // Console.WriteLine("Timeout: " + t.Message);                   
                    Console.WriteLine("*");
                }
                catch (Exception e)
                {
                    throw (new ApplicationException("Error while listening: " + e.Message));
                }
            }
            HIDStream.Close();
            return (computedMessage); 
        }

        protected virtual void OnStreamClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Stream closed.");
            HIDStream.Closed -= this.OnStreamClosed;
            HIDStreamOpen = false;
        }
    }
}

