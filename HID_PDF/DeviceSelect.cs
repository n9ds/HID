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

namespace HID_PDF
{
    public partial class DeviceSelect : Form
    {
        public String SelectedDevice { get; set; }

        public DeviceSelect()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load(Properties.Settings.Default.ConfigFile);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/devices/device");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("System name: " + node.SelectSingleNode("systemname").InnerText);
                listBox1.Items.Add(node.SelectSingleNode("systemname").InnerText);
            }
        }

        private void OK_Clicked(object sender, EventArgs e)
        {
            // Select device, Etc.
            SelectedDevice = listBox1.SelectedItem.ToString();
            this.Close();    
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
