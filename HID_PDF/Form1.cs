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
using HID_PDF.Forms;
using HID_PDF.Data;
using HID_PDF.Domain;

namespace HID_PDF
{
    public partial class Form1 : Form
    {
        private FootPedalMonitor FootPedalMonitor;
        private Thread DeviceThread;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private delegate void FootPedalNotification(object sender, HIDEventArgs e);
        private SongLibrary SongLibrary;
        private SetlistShow OpenSetlist;
        private SongSelect SongSelectDlg;
        private SetlistSelect SetlistSelectDlg;
        private SetlistShow SetlistShowDlg;
        private LibrarySelect LibrarySelectDlg;

        public enum Modes
        {
            Create,
            Open,
            Edit,
            Delete
        };

        public event EventHandler<SongSelectedEventArgs> SongSelected;

        private class DeviceConfigParams
        {
            public String ConfigFile { get; set; }
            public String DeviceName { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            SongLibrary = new SongLibrary();
            SongSelectDlg = null;
            SetlistSelectDlg = null;
            LibrarySelectDlg = null;
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


        #region "Control Events"
        private void First_Click(object sender, EventArgs e)
        {
            FootPedalMonitor.SendMessage("00-02-00");
            axAcroPDF1.gotoFirstPage();
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

        private void NextSong_Click(object sender, EventArgs e)
        {
            OpenSetlist.NextSong(sender, e);
        }

        private void PrevSong_Click(object sender, EventArgs e)
        {
            OpenSetlist.PrevSong(sender, e);
        }

        #endregion

        #region "PDF Specific"
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
        #endregion

        #region "Form Events"

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
        #endregion

        #region "Device Events"
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
            if (SongSelectDlg == null)
            {
                SongSelectDlg = new SongSelect(e.LibraryId);
                SongSelectDlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            }
            SongSelectDlg.Show();
        }

        private void Dlg_SetlistSelected(object sender, SetlistSelectedEventArgs e)
        {
            if (SetlistShowDlg == null || SetlistShowDlg.IsDisposed)
            {
                SetlistShowDlg = new SetlistShow(e.SetlistId);
                OpenSetlist = SetlistShowDlg;
                SetlistShowDlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            }
            SetlistShowDlg.Show();
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
            //axAcroPDF1.
            this.Close();
        }

        #endregion
        // TODO: Check to make sure modeless dialogs aren't already open.
        #region "Other events"
        private void SongSelect(object sender, EventArgs e)
        {
            if (SongSelectDlg == null || SongSelectDlg.IsDisposed)
            {
                SongSelectDlg = new SongSelect();
                SongSelectDlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            }
            SongSelectDlg.Show();
        }

        private void LibrarySelect (object sender, EventArgs e)
        {
            if (LibrarySelectDlg == null || SongSelectDlg.IsDisposed)
            {
                LibrarySelectDlg = new LibrarySelect();
                LibrarySelectDlg.LibrarySelected += new EventHandler<LibrarySelectedEventArgs>(Dlg_LibrarySelected);
            }
            LibrarySelectDlg.Show();
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
            if (SongSelectDlg == null || SongSelectDlg.IsDisposed)
            {
                SongSelectDlg = new SongSelect();
                SongSelectDlg.SongSelected += new EventHandler<SongSelectedEventArgs>(Dlg_SongSelected);
            }
            SongSelectDlg.Show();
        }

        private void OpenLibrariesDialog(object sender, EventArgs e)
        {
            LibrarySelectDlg = new LibrarySelect();
            LibrarySelectDlg.LibrarySelected += new EventHandler<LibrarySelectedEventArgs>(Dlg_LibrarySelected);
            LibrarySelectDlg.Show();
        }

        private void OpenSetlistsDialog(object sender, EventArgs e)
        {
            SetlistSelectDlg = new SetlistSelect();
            SetlistSelectDlg.SetlistSelected += new EventHandler<SetlistSelectedEventArgs>(Dlg_SetlistSelected);
            SetlistSelectDlg.Show();
        }
        #endregion

        #region "Deprecated/Not implented yet"
        //public void LoadSetlist(int SetlistId)
        //{
        //    Setlist setlist = SongLibrary.Setlists
        //        .Include("SetlistEntries.Song")
        //        .Where(S => S.Id == SetlistId).FirstOrDefault();
        //    if (setlist == null)
        //    {
        //        throw (new NotImplementedException());
        //    }
        //    List<SetlistEntry> Set = setlist.SetlistEntries.ToList().OrderBy(s => s.SetOrder).ToList();
        //    foreach (SetlistEntry sl in Set)
        //    {
        //        Song s = sl.Song;
        //        // The songs don't have a set order so we put in a dummy value.  Makes moving items back and forth easier.
        //        listView1.Items.Add(new ListViewItem(new[] { s.Title, s.Key, s.FirstNote, s.Id.ToString(), sl.SetOrder.ToString() }));
        //    }
        //}

        //private void NextSong(object sender, EventArgs e)

        //{
        //    var NextSelection = 0;
        //    if (listView1.SelectedItems.Count == 0)
        //    {
        //        NextSelection = 0;
        //    }
        //    else
        //    {
        //        NextSelection = (listView1.SelectedIndices[0] < listView1.Items.Count - 1 ? listView1.SelectedIndices[0] + 1 : listView1.Items.Count - 1);
        //    }
        //    listView1.Items[NextSelection].Selected = true;
        //    listView1.Select();
        //}

        //private void PrevSong(object sender, EventArgs e)
        //{
        //    var CurrentSelection = (listView1.SelectedIndices.Count == 0 ? 0 : listView1.SelectedIndices[0]);
        //    var PrevSelection = (CurrentSelection > 0 ? CurrentSelection - 1 : 0);
        //    listView1.Items[PrevSelection].Selected = true;
        //    listView1.Select();
        //}

        //private void OpenSong(object sender, EventArgs e)
        //{
        //    if (listView1.SelectedIndices.Count > 0)
        //    {
        //        var Song = listView1.SelectedItems[0].SubItems[3].Text;
        //        var SongId = int.Parse(Song);
        //        SongSelectedEventArgs songSelectedEventArgs = new SongSelectedEventArgs();
        //        songSelectedEventArgs.SongId = SongId;
        //        songSelectedEventArgs.Mode = (int)Modes.Open;
        //        songSelectedEventArgs.Filename = SongLibrary.Songs.Where(T => T.Id == SongId).FirstOrDefault().Filepath;
        //        SongSelected(this, songSelectedEventArgs);
        //    }
        //}
        #endregion
    }
}
