using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HID_PDF;
using HID_PDF.Data;
using HID_PDF.Domain;
using HID_PDF.Infrastructure;

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
            LoadLibraries();
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
            // Select libraries it happens to be in.
            var Libraries = SongLibrary.Libraries.ToList().Where(s => s.Songs.Contains(Song)).ToList();
            foreach (var l in Libraries)
            {
                this.Libraries.SelectedItem = l.Title;
            }
        }

        private void LoadLibraries()
        {
            var Libraries = SongLibrary.Libraries.OrderBy(l => l.Title).Select(t => t.Title).ToList();
            this.Libraries.DataSource = Libraries;
        }

        private void Save(object sender, EventArgs e)
        {
            var IsFormValid = ValidateForm();
            CancelClicked = false;
            if (!IsFormValid)
            {
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
            // Another place where the small volume makes it not worth while to selectively remove.
            // Just remove them all and add them back in.
            foreach (var SItem in this.Libraries.Items)
            {
                var Library = SongLibrary.Libraries.Where(t => t.Title == SItem.ToString()).FirstOrDefault();
                if (Library.Songs.Contains(Song))
                {
                    Library.Songs.Remove(Song);
                }
            }
            foreach (var SItem in this.Libraries.SelectedItems)
            {
                var Library = SongLibrary.Libraries.Where(t => t.Title == SItem.ToString()).FirstOrDefault();
                if (!Library.Songs.Contains(Song))
                {
                    Library.Songs.Add(Song);
                }
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
            // TODO: Make Validation configurable.
            Validation validation = new Validation();
            List<String> FieldsToValidate = new List<String>();
            FieldsToValidate.Add("SongTitle");
            FieldsToValidate.Add("SongArtist");
            FieldsToValidate.Add("SongFilename");
            FieldsToValidate.Add("SongInstrument");
            if (!validation.ValidateForm(this, FieldsToValidate))
            {
                validation.ShowErrors();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void RedrawChildren(object sender, EventArgs e)
        {
        }
    }
}
