using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HID_PDF.Infrastructure;

namespace HID_PDF.Forms
{
    public partial class DeviceConfigure : Form
    {
        public class HIDListboxItem
        {
            public String Text { get; set; }
            public bool Configured { get; set; }

            private HIDListboxItem()
            {
                Text = "";
                Configured = false;
            }

            public HIDListboxItem(String Text)
            {
                this.Text = Text;
                Configured = false;
            }

            public HIDListboxItem(bool Configured)
            {
                this.Configured = Configured;
                Text = "";
            }
        }

        public DeviceConfigParms deviceConfigParms { get; set; }
        public IList<String> AttachedDevices { get; set; }

        public DeviceConfigure()
        {
            // TODO: Read Config file, populate List Box
            // TODO: Write Config file.
            InitializeComponent();
        }

        public void Form_Load(Object sender, EventArgs e)
        {
            LoadConfiguration();
        }
        public void LoadConfiguration()
        {

            Actions.Items.Add(new HIDListboxItem("next"));
            Actions.Items.Add(new HIDListboxItem("prev"));
            Actions.Items.Add(new HIDListboxItem("first"));
            Actions.Items.Add(new HIDListboxItem("last"));

            lblDeviceName.Text = deviceConfigParms.DeviceName;
            XmlDocument doc = new XmlDocument();

            doc.Load(deviceConfigParms.ConfigFile);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/devices/device");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("System name: " + node.SelectSingleNode("systemname").InnerText);
                if (node.SelectSingleNode("systemname").InnerText.Equals(deviceConfigParms.DeviceName))
                {
                    XmlNodeList xmlMessages = node.SelectNodes("./messages");
                    XmlNodeList xmlMessageList = xmlMessages.Item(0).SelectNodes("./message");
                    foreach (XmlNode msgnode in xmlMessageList)
                    {
                        var nodeText = msgnode.SelectSingleNode("messageevent").InnerText;
                        // TODO: This may not set a true to false.  Fix that.
                        foreach (HIDListboxItem item in Actions.Items)
                        {
                            if (item.Text.Equals(nodeText))
                            {
                                item.Configured = true;
                            }
                        }
                    }
                }
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DrawItemHandler(object sender, DrawItemEventArgs e)
        {
            HIDListboxItem item = (HIDListboxItem)Actions.Items[e.Index];
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(
                item.Text, 
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular), 
                new SolidBrush((item.Configured ? Color.Red : Color.Green)), 
                e.Bounds);
        }
    }
}
