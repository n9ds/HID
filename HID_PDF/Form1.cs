﻿using System;
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
using HID_PDF.Forms;

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
                var dlg = new OpenFileDialog();
                // set file filter of dialog   
                dlg.Filter = "pdf files (*.pdf) |*.pdf;";
                dlg.ShowDialog();
                if (dlg.FileName != null)
                {
                    OpenPDF(dlg.FileName);
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

        private void HelpAbout_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var dlg = new HelpAbout();
            dlg.Show();
        }

        private void DeviceSelect(object sender, EventArgs e)
        {
            DeviceSelect dlg = new DeviceSelect();
            var rc = dlg.ShowDialog();
            if (rc == DialogResult.OK)
            {
                var deviceConfigParams = new DeviceConfigParams();
                deviceConfigParams.ConfigFile = Properties.Settings.Default.ConfigFile;
                deviceConfigParams.DeviceName = dlg.SelectedDevice;
                InitializeDevice(deviceConfigParams);
            }
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

        private void Dlg_SongSelected(object sender, SongSelectedEventArgs e)
        {
            switch (e.Mode)
            {
                case (int)HID_PDF.Forms.SongSelect.Modes.Open:
                    if (System.IO.File.Exists(e.Filename))
                    {
                        OpenPDF(e.Filename);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + e.Filename + " not found", "File error", MessageBoxButtons.RetryCancel);
                    }
                    break;

                case (int)HID_PDF.Forms.SongSelect.Modes.Delete:
                    MessageBox.Show("You want to delete " + e.Filename);
                    break;

                default:
                    MessageBox.Show("Unsupported Song Mode");
                    break;
            }
        }

        private void Dlg_LibrarySelected(object sender, LibrarySelectedEventArgs e)
        {
            SongSelect dlg = new SongSelect(e.LibraryId);
            dlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            dlg.Show();
        }

        private void Dlg_SetlistSelected(object sender, SetlistSelectedEventArgs e)
        {
            SongSelect dlg = new SongSelect(e.SetlistId);
            dlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            dlg.Show();
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

        private void FileExit(object sender, EventArgs e)
        {
            if (DeviceThread != null)
            {
                DeviceThread.Abort();
            }
            this.Close();
        }

        private void SongSelect(object sender, EventArgs e)
        {
            SongSelect dlg = new SongSelect();
            dlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            dlg.Show();
        }

        private void LibrarySelect (object sender, EventArgs e)
        {
            LibrarySelect dlg = new LibrarySelect();
            dlg.LibrarySelected += new EventHandler<LibrarySelectedEventArgs>(Dlg_LibrarySelected);
            dlg.Show();
        }

        private void OpenPDF (String Filename)
        {
            axAcroPDF1.LoadFile(Filename);
            axAcroPDF1.setShowToolbar(false);
            axAcroPDF1.setPageMode("None");
            axAcroPDF1.setView("Fit");
            this.Text = Filename;
            DeviceThread = new Thread(new ThreadStart(FootPedalMonitor.Read));
            DeviceThread.Start();
        }

        private void OpenSongsDialog(object sender, EventArgs e)
        {
            SongSelect dlg = new SongSelect();
            dlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            dlg.Show();
        }

        private void OpenLibrariesDialog(object sender, EventArgs e)
        {
            LibrarySelect dlg = new LibrarySelect();
            dlg.LibrarySelected += new EventHandler<LibrarySelectedEventArgs>(Dlg_LibrarySelected);
            dlg.Show();
        }

        private void OpenSetlistsDialog(object sender, EventArgs e)
        {
            SetlistSelect dlg = new SetlistSelect();
            dlg.SetlistSelected += new EventHandler<SetlistSelectedEventArgs>(Dlg_SetlistSelected);
            dlg.Show();
        }
    }
}
