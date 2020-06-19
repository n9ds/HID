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
    public partial class SongMaintenance : Form
    {
        public SongLibrary SongLibrary { get; set; }
        public Song Song { get; set; }
        public SongSelect.Modes Mode { get; set; }
        public Dictionary<String, String> Errors { get; set; }
        public bool CancelClicked { get; set; }

        public SongMaintenance()
        {
            SongLibrary = new SongLibrary();
            InitializeComponent();
            Errors = new Dictionary<String, String>();
            Song = null;
            Mode = SongSelect.Modes.Create;
        }

        public SongMaintenance(int SongId, SongSelect.Modes DlgMode)
            : this ()
        {
            Song = SongLibrary.Songs.Where(s => s.Id == SongId).FirstOrDefault();
            if (Song != null)
            {
                this.SongId.Text = Song.Id.ToString();
                SongTitle.Text = Song.Title;
                SongArtist.Text = Song.Artist;
                SongFilename.Text = Song.Filepath;
                SongKeyIsMinor.Checked = Song.Major; // Sign error!
                Shown += new EventHandler(ShowSong);
                SongSelect.Modes DeleteMode = SongSelect.Modes.Delete;
                SongDelete.Visible = (DeleteMode.CompareTo(DlgMode) == 0);
                SongSave.Visible = !SongDelete.Visible;
            }
            Mode = DlgMode;
        }

        private void ShowSong(Object sender, EventArgs e)
        {
            SongKey.SelectedItem = Song.Key;
            SongInstrument.SelectedItem = Song.Instrument;
            SongFirstNote.SelectedItem = Song.FirstNote;
            FileType.SelectedItem = Song.Filetype;
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
                //var ErrorText = new StringBuilder();
                foreach (var errorMsg in Errors)
                {
                    ErrorMessages.Rows.Add(new[] { errorMsg.Key, errorMsg.Value });
                }
                ErrorMessages.Visible = true;
                return;
            }
            if (Mode == SongSelect.Modes.Create)
            {
                Song = new Song();
            }
            Song.Title = SongTitle.Text;
            Song.Artist = SongArtist.Text;
            Song.Instrument = SongInstrument.SelectedItem.ToString();
            Song.Key = SongKey.SelectedItem.ToString(); ;
            Song.Major = true;
            Song.Filepath = SongFilename.Text;
            if (SongFirstNote.SelectedItem != null)
            {
                Song.FirstNote = SongFirstNote.SelectedItem.ToString();
            }
            else
            {
                Song.FirstNote = null;
            }
            if (Mode == SongSelect.Modes.Create)
            {
                SongLibrary.Songs.Add(Song);
            }
            SongLibrary.SaveChanges();
            Close();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (Song == null)
            {
                MessageBox.Show("Not found");
            }
            else
            {
                DialogResult rc = MessageBox.Show("Delete " + Song.Title + "?","Confirm Delete",MessageBoxButtons.YesNoCancel);
                if (rc == DialogResult.Yes)
                {
                    SongLibrary.Songs.Remove(Song);
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
            OpenFileDialog dlg = new OpenFileDialog
            {
                // set file filter of dialog   
                Filter = "pdf files (*.pdf) |*.pdf;"
            };
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
