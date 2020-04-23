using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HID_PDF.Properties;

namespace HID_PDF
{
    public partial class Form1 : Form
    {
        private FootPedalMonitor FootPedalMonitor;
        private Thread DeviceThread;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private delegate void FootPedalNotification(object sender, HIDEventArgs e);
        private class DeviceConfigParams
        {
            public String ConfigFile { get; set; }
            public String DeviceName { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            FootPedalMonitor = new FootPedalMonitor();
            DeviceConfigParams deviceConfigParams = new DeviceConfigParams();
            if (String.IsNullOrEmpty(Properties.Settings.Default.ConfigFile))
            {
                Properties.Settings.Default.ConfigFile = "DeviceConfig.xml";
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.DeviceName))
            {
                Properties.Settings.Default.DeviceName = "xxUSB NETVISTA FULL WIDTH KEYBOARD";
            }
            deviceConfigParams.ConfigFile = Properties.Settings.Default.ConfigFile;
            deviceConfigParams.DeviceName = Properties.Settings.Default.DeviceName;
            InitializeDevice(deviceConfigParams);
            FootPedalMonitor.OnHidDeviceRead += this.HidDeviceRead;
        }

        private void InitializeDevice(DeviceConfigParams deviceConfigParams)
        {
            FootPedalMonitor.ConfigFile = deviceConfigParams.ConfigFile;
            FootPedalMonitor.DeviceName = deviceConfigParams.DeviceName;
            FootPedalMonitor.Config();
            if (FootPedalMonitor.DeviceFound)
            {
                // If there's a thread already running, kill it first.
                if (DeviceThread != null)
                {
                    DeviceThread.Abort();
                    DeviceThread = null;
                }
                toolStripStatusLabel1.Text = FootPedalMonitor.DeviceName;
                toolStripStatusLabel1.ForeColor = Color.Black;
                Properties.Settings.Default.DeviceName = FootPedalMonitor.DeviceName;
                //DeviceThread = new Thread(FootPedalMonitor.Read);
                //DeviceThread.Start();
            }
            else
            {
                toolStripStatusLabel1.Text = FootPedalMonitor.DeviceName + " NOT FOUND";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }

        private void OpenPDF_Click(object sender, EventArgs e)
        {
            // Create object of Open file dialog class  
            {
                OpenFileDialog dlg = new OpenFileDialog();
                // set file filter of dialog   
                dlg.Filter = "pdf files (*.pdf) |*.pdf;";
                dlg.ShowDialog();
                if (dlg.FileName != null)
                {
                    // use the LoadFile(ByVal fileName As String) function for open the pdf in control  
                    axAcroPDF1.LoadFile(dlg.FileName);
                    axAcroPDF1.setShowToolbar(false);
                    axAcroPDF1.setPageMode("None");
                    axAcroPDF1.setView("Fit");
                    this.Text = dlg.FileName;
                    DeviceThread = new Thread(new ThreadStart(FootPedalMonitor.Read));
                    DeviceThread.Start();

                }
            }
        }

        private void First_Click(object sender, EventArgs e)
        {
            FootPedalMonitor.SendMessage("00-02-00");
            //axAcroPDF1.gotoFirstPage();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoNextPage();
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoPreviousPage();
        }

        private void Last_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoLastPage();
        }

        private void ResizePDF(object sender, EventArgs e)
        {
            RedrawChildren(sender, e);
            //Control control = (Control)sender;
            //this.SuspendLayout();
            //Size pdfSize = new Size(control.Width, control.Height - 100);
            //axAcroPDF1.ClientSize = pdfSize;
            //axAcroPDF1.setPageMode("PDUseNone");
            //Control parent = control.GetControl("NextButton");
            //int buttonHeight = this.prevButton.Height;
            //this.prevButton.Location = new System.Drawing.Point(267, control.Height - 100);
            //this.nextButton.Location = new System.Drawing.Point(361, control.Height - 100);
            //this.ResumeLayout(false);
        }

        private void RedrawChildren(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            Control child = this.Controls["prevButton"];
            int controlHeight = form.Height - 100;
            child.Location = new Point(child.Left, controlHeight);
            child = this.Controls["nextButton"];
            child.Location = new Point(child.Left, controlHeight);
            child = this.Controls["firstButton"];
            child.Location = new Point(child.Left, controlHeight);
            child = this.Controls["lastButton"];
            child.Location = new Point(child.Left, controlHeight);
            //child = this.Controls["openPDF"];
            //child.Location = new Point(child.Left, form.Height - 100);
            Size pdfSize = new System.Drawing.Size(form.Width - 25, controlHeight);
            axAcroPDF1.ClientSize = pdfSize;
            axAcroPDF1.setPageMode("PDUseNone");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowLocation != null)
            {
                this.Location = Settings.Default.WindowLocation;
            }
            if (Settings.Default.WindowSize != null)
            {
                this.ClientSize = Settings.Default.WindowSize;
                this.RedrawChildren(sender, e);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(782, 614);
                this.axAcroPDF1.Size = new System.Drawing.Size(756, 573);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.WindowLocation = this.Location;
            FootPedalMonitor.HIDStreamOpen = false;
            // Copy window size to app settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            // Save settings
            Settings.Default.Save();
        }

        private void HelpAbout_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form dlg = new HelpAbout();
            dlg.Show();
        }

        private void DeviceSelect(object sender, EventArgs e)
        {
            DeviceSelect dlg = new DeviceSelect();
            var rc = dlg.ShowDialog();
            if (rc == DialogResult.OK)
            {
                DeviceConfigParams deviceConfigParams = new DeviceConfigParams();
                deviceConfigParams.ConfigFile = Properties.Settings.Default.ConfigFile;
                deviceConfigParams.DeviceName = dlg.SelectedDevice;
                InitializeDevice(deviceConfigParams);
            }
        }

        private void FileExit(object sender, EventArgs e)
        {
            DeviceThread.Abort();
            this.Close();
        }

        public void HidDeviceRead(object sender, HIDEventArgs e)
        {
            if (!axAcroPDF1.IsDisposed)
            {
                switch (e.Message)
                {
                    case "prev":
                        if (InvokeRequired)
                        {
                            Invoke(new FootPedalNotification(HidDeviceRead), new object[] { sender, e });
                        }
                        else
                        {
                            Prev_Click(sender, e);
                        }
                        break;
                    case "next":
                        if (InvokeRequired)
                        {
                            Invoke(new FootPedalNotification(HidDeviceRead), new object[] { sender, e });
                        }
                        else
                        {
                            Next_Click(sender, e);
                        }
                        break;
                    case "first":
                        if (InvokeRequired)
                        {
                            Invoke(new FootPedalNotification(HidDeviceRead), new object[] { sender, e });
                        }
                        else
                        {
                            First_Click(sender, e);
                        }
                        break;
                    case "last":
                        if (InvokeRequired)
                        {
                            Invoke(new FootPedalNotification(HidDeviceRead), new object[] { sender, e });
                        }
                        else
                        {
                            Last_Click(sender, e);
                        }
                        break;

                    case "off":
                        break;
                    default: throw (new NotSupportedException("Message " + e.Message + " not supported."));
                }
            }
        }
    }
}
