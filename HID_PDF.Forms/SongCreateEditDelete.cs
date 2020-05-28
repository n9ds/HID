using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HID_PDF;
using HID_PDF.Data;
using HID_PDF.Domain;

namespace HID_PDF.Forms
{
    public partial class SongCreateEditDelete : Form
    {
        public SongLibrary SongLibrary { get; set; }
        public Song song { get; set; }
        public SongSelect.Modes Mode { get; set; }
        public Dictionary<String, String> Errors { get; set; }
        public bool CancelClicked { get; set; }

        public SongCreateEditDelete()
        {
            SongLibrary = new SongLibrary();
            InitializeComponent();
            Errors = new Dictionary<String, String>();
            song = null;
            Mode = SongSelect.Modes.Create;
        }

        public SongCreateEditDelete(int SongId, SongSelect.Modes DlgMode)
            : this ()
        {
            song = SongLibrary.Songs.Where(s => s.Id == SongId).FirstOrDefault();
            if (song != null)
            {
                this.SongId.Text = song.Id.ToString();
                SongTitle.Text = song.Title;
                SongArtist.Text = song.Artist;
                SongFilename.Text = song.Filepath;
                SongKeyIsMinor.Checked = song.Major; // Sign error!
                Shown += new EventHandler(ShowSong);
                SongSelect.Modes DeleteMode = SongSelect.Modes.Delete;
                SongDelete.Visible = (DeleteMode.CompareTo(DlgMode) == 0);
                SongSave.Visible = !SongDelete.Visible;
            }
            Mode = DlgMode;
        }

        private void ShowSong(Object sender, EventArgs e)
        {
            SongKey.SelectedItem = song.Key;
            SongInstrument.SelectedItem = song.Instrument;
            SongFirstNote.SelectedItem = song.FirstNote;
            FileType.SelectedItem = song.Filetype;
        }

        private void Save(object sender, EventArgs e)
        {
            ErrorMessages.Visible = false;
            ErrorMessages.Rows.Clear();
            var IsFormValid = ValidateForm();
            CancelClicked = false;
            if (!IsFormValid)
            {
                MessageBox.Show("Oops: ");
                var ErrorText = new StringBuilder();
                foreach (var errorMsg in Errors)
                {
                    ErrorMessages.Rows.Add(new[] { errorMsg.Key, errorMsg.Value });
                }
                ErrorMessages.Visible = true;
                return;
            }
            if (Mode == SongSelect.Modes.Create)
            {
                song = new Song();
            }
            song.Title = SongTitle.Text;
            song.Artist = SongArtist.Text;
            song.Instrument = SongInstrument.SelectedItem.ToString();
            song.Key = SongKey.SelectedItem.ToString(); ;
            song.Major = true;
            song.Filepath = SongFilename.Text;
            if (SongFirstNote.SelectedItem != null)
            {
                song.FirstNote = SongFirstNote.SelectedItem.ToString();
            }
            else
            {
                song.FirstNote = null;
            }
            if (Mode == SongSelect.Modes.Create)
            {
                SongLibrary.Songs.Add(song);
            }
            SongLibrary.SaveChanges();
            Close();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (song == null)
            {
                MessageBox.Show("Not found");
            }
            else
            {
                DialogResult rc = MessageBox.Show("Delete " + song.Title + "?","Confirm Delete",MessageBoxButtons.YesNoCancel);
                if (rc == DialogResult.Yes)
                {
                    SongLibrary.Songs.Remove(song);
                    SongLibrary.SaveChanges();
                    Close();
                }
            }
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            CancelClicked = true;
            Close();
        }

        private void SelectFile(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            // set file filter of dialog   
            dlg.Filter = "pdf files (*.pdf) |*.pdf;";
            dlg.ShowDialog();
            SongFilename.Text = dlg.FileName;
        }
        private bool ValidateForm()
        {
            // TODO: Iterate through a list of fields.
            // TODO: Make Validation configurable.
            bool IsFormValid = ValidateSongTextField("SongTitle");
            IsFormValid &= ValidateSongTextField("SongArtist");
            IsFormValid &= ValidateSongTextField("SongFilename");
            IsFormValid &= ValidateSongListBox("SongInstrument");
            return ( IsFormValid );
        }
        private bool ValidateSongTextField(String Fieldname)
        {
            Control TextField = this.Controls.Find(Fieldname, true).FirstOrDefault();
            if (TextField == null)
            {
                throw (new NotImplementedException("Validation  Error: Field " + Fieldname + " does not exist.\n"));
            }
            if (CancelClicked || !String.IsNullOrEmpty(((TextBox)TextField).Text))
            {
                TextField.BackColor = Color.Empty;
                Errors.Remove(Fieldname);
                return true;
            }
            else
            {
                TextField.BackColor = Color.Red;
                Errors.Add(Fieldname, "Cannot be blank");
                return false;
            }
        }

        private bool ValidateSongListBox(String Fieldname)
        {
            Control Listbox = this.Controls.Find(Fieldname, true).FirstOrDefault();
            if (Listbox == null)
            {
                throw (new NotImplementedException("Validation  Error: Field " + Fieldname + " does not exist.\n"));
            }
            if (CancelClicked || ((ListBox)Listbox).SelectedItems.Count > 0)
            {
                Listbox.BackColor = Color.Empty;
                Errors.Remove(Fieldname);
                return true;
            }
            else
            {
                Listbox.BackColor = Color.Red;
                Errors.Add(Fieldname, "Select an item");
                return false;
            }
        }

        private void RedrawChildren(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            Control child = this.ErrorMessages;
            int ChildBottom = form.Height - 100;
            child.Height = ChildBottom - child.Top;
        }
    }
}
