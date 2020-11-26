using HidSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HID_PDF.Forms
{
    public partial class DeviceAdd : Form
    {
        public String SelectedDevice { get; set; }

        public DeviceAdd(IList<String> AvailableDeviceList)
        {
            InitializeComponent();
            foreach (var device in AvailableDeviceList)
            {
                AvailableDevices.Items.Add(device);
            }

        }
        private void OK_Clicked(object sender, EventArgs e)
        {
            // Select device, Etc.
            SelectedDevice = AvailableDevices.SelectedItem.ToString();
            this.Close();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
