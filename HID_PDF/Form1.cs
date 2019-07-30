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

        public Form1()
        {
            InitializeComponent();
            FootPedalMonitor = new FootPedalMonitor();
            //FootPedalMonitor.Setup("Foot Pedal");
            FootPedalMonitor.Setup("USB NETVISTA FULL WIDTH KEYBOARD");
            Thread thread = new Thread(FootPedalMonitor.Read);
            thread.Start();
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
                    axAcroPDF1.setView("FitV");
                    this.Text = dlg.FileName;
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoNextPage();
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoPreviousPage();
        }

        private void ResizePDF(object sender, EventArgs e)
        {
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
            child.Location = new Point(child.Left, form.Height - 100);
            child = this.Controls["nextButton"];
            child.Location = new Point(child.Left, form.Height - 100);
            child = this.Controls["openPDF"];
            child.Location = new Point(child.Left, form.Height - 100);
            Size pdfSize = new System.Drawing.Size(form.Width - 25, form.Height - 100);
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
    }
}
