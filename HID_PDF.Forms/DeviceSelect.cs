using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using HidSharp;
using HID_PDF;

namespace HID_PDF.Forms
{
    public partial class DeviceSelect : Form
    {
        public String SelectedDevice { get; set; }

        public DeviceSelect(String ConfigFile)
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigFile);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/devices/device");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("System name: " + node.SelectSingleNode("systemname").InnerText);
                ConfiguredDevices.Items.Add(node.SelectSingleNode("systemname").InnerText);
            }
        }
// TODO: Show list of attached devices, Select one to add/config
// TODO: Show a list of added devices, select one to config
// TODO: Dialog to configure device

        private void OK_Clicked(object sender, EventArgs e)
        {
            // Select device, Etc.
            SelectedDevice = ConfiguredDevices.SelectedItem.ToString();
            this.Close();    
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
