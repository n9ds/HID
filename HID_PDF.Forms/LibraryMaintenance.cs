using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HID_PDF;
using HID_PDF.Data;
using HID_PDF.Domain;
using HID_PDF.Infrastructure;

namespace HID_PDF.Forms
{
    public partial class LibraryMaintenance : Form
    {
        public SongLibrary SongLibrary { get; set; }
        public Library Library { get; set; }
        public IList<Song> Songs { get; set; }
        public SongSelect.Modes Mode { get; set; }
        public Dictionary<String, String> Errors { get; set; }
        public ListView SongsAtStart { get; set; }
        public bool CancelClicked { get; set; }

        public LibraryMaintenance()
        {
            SongLibrary = new SongLibrary();
            Songs = new List<Song>();
            InitializeComponent();
            Errors = new Dictionary<String, String>();
            Library = null;
            SongsAtStart = new ListView();
            LoadSongList(Library);
            Mode = SongSelect.Modes.Create;
        }

        public LibraryMaintenance(int LibraryId, SongSelect.Modes DlgMode)
            : this()
        {
            Library = SongLibrary.Libraries.Where(s => s.Id == LibraryId).FirstOrDefault();
            if (Library != null)
            {
                this.LibraryId.Text = Library.Id.ToString();
                LibraryTitle.Text = Library.Title;
                LibraryDescription.Text = Library.Description;
                Songs = Library.Songs.ToList();
                //Shown += new EventHandler(ShowLibrary);
                LoadSongList(Library);
            }
            Mode = DlgMode;
        }

        private void LoadSongList(Library library)
        {
            List<Song> Songs;
            List<Song> AllSongs;
            List<Song> RemainingSongs;
            // First load all the songs that are in all the libraries.
            AllSongs = Songs = SongLibrary.Songs.OrderBy(S => S.Title).ToList();
            // Then get the ones in the selected library and the ones that aren't.
            if (library == null)
            {
                Songs = AllSongs;
                RemainingSongs = new List<Song>();
            }
            else
            {
                Songs = SongLibrary.Libraries.Where(l => l.Id == library.Id).First()
                    .Songs
                    .OrderBy(S => S.Title)
                    .ToList();
                RemainingSongs = AllSongs.Except<Song>(Songs).ToList();
            }
            LoadListView(Songs, SongsAtStart); // Need to have a separate list independent of Library for the .Except later on.
            LoadListView(Songs, SongsInLibrary);
            LoadListView(RemainingSongs, SongsAvailable);
        }

        private void LoadListView(IList<Song> songs, ListView listView)
        {
            ListViewGroup ListGroup = new ListViewGroup("");
            String CurrentGroup = "";
            listView.Items.Clear();
            listView.Groups.Clear();
            foreach (Song s in songs)
            {
                if (!s.Title.Substring(0, 1).Equals(CurrentGroup))
                {
                    CurrentGroup = s.Title.Substring(0, 1);
                    ListGroup = new ListViewGroup(CurrentGroup, CurrentGroup);
                    listView.Groups.Add(ListGroup);
                }
                listView.Items.Add(new ListViewItem(new[] { s.Title, s.Artist, s.Instrument, s.Id.ToString() }, ListGroup));
            }
        }

        private void Save(object sender, EventArgs e)
        {
            ErrorMessages.Visible = false;
            ErrorMessages.Rows.Clear();
            var IsFormValid = ValidateForm();
            CancelClicked = false;
            if (!IsFormValid)
            {
                return;
            }
            if (Mode == SongSelect.Modes.Create)
            {
                Library = new Library();
            }
            Library.Title = LibraryTitle.Text;
            Library.Description = LibraryDescription.Text;
            if (Mode == SongSelect.Modes.Create)
            {
                SongLibrary.Libraries.Add(Library);
            }
            var Songs_Start = SongsAtStart.Items.Cast<ListViewItem>();
            var Songs_End = SongsInLibrary.Items.Cast<ListViewItem>();
            // Except() Items in the first set that don't appear in the second.
            var SongsToRemoveFromLibrary = Songs_Start.Except<ListViewItem>(Songs_End, new ListViewItemComparer()).ToList(); 
            var SongsToAddToLibrary = Songs_End.Except<ListViewItem>(Songs_Start, new ListViewItemComparer()).ToList();
            int SongId;
            foreach (ListViewItem SongToRemove in SongsToRemoveFromLibrary)
            {
                var rc = int.TryParse(SongToRemove.SubItems[3].Text, out SongId);
                if (rc)
                {
                    Library.Songs.Remove(SongLibrary.Songs.Where(s => s.Id == SongId).FirstOrDefault());
                }
            }
            // Update the list of songs.
            foreach (ListViewItem SongToAdd in SongsToAddToLibrary)
            {
                var rc = int.TryParse(SongToAdd.SubItems[3].Text, out SongId);
                if (rc)
                {
                    Library.Songs.Add(SongLibrary.Songs.Where(s => s.Id == SongId).FirstOrDefault());
                }
            }
            SongLibrary.SaveChanges();
            Close();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (Library == null)
            {
                MessageBox.Show("Not found");
            }
            else
            {
                DialogResult rc = MessageBox.Show("Delete " + Library.Title + "?", "Confirm Delete", MessageBoxButtons.YesNoCancel);
                if (rc == DialogResult.Yes)
                {
                    SongLibrary.Libraries.Remove(Library);
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
        // We'll leave this in there in case we want to import a CSV or something.
        private void SelectFile(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog {
                // set file filter of dialog   
                Filter = "pdf files (*.pdf) |*.pdf;"
            };
            dlg.ShowDialog();
            //SongFilename.Text = dlg.FileName;
        }
        private bool ValidateForm()
        {
            // TODO: Make Validation configurable.
            Validation validation = new Validation();
            List<String> FieldsToValidate = new List<String>();
            FieldsToValidate.Add("LibraryTitle");
            FieldsToValidate.Add("LibraryDescription");
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

        //private bool ValidateSongListBox(String Fieldname)
        //{
        //    Control Listbox = this.Controls.Find(Fieldname, true).FirstOrDefault();
        //    if (Listbox == null)
        //    {
        //        throw (new NotImplementedException("Validation  Error: Field " + Fieldname + " does not exist.\n"));
        //    }
        //    if (CancelClicked || ((ListBox)Listbox).SelectedItems.Count > 0)
        //    {
        //        Listbox.BackColor = Color.Empty;
        //        Errors.Remove(Fieldname);
        //        return true;
        //    }
        //    else
        //    {
        //        Listbox.BackColor = Color.Red;
        //        Errors.Add(Fieldname, "Select an item");
        //        return false;
        //    }
        //}

        private void RedrawChildren(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            Control child = this.ErrorMessages;
            int ChildBottom = form.Height - 100;
            child.Height = ChildBottom - child.Top;
        }

        private void AddSelected(Object sender, EventArgs e)
        {
            MoveSelected(SongsAvailable, SongsInLibrary);
            SortListViewGroups(SongsInLibrary);
        }

        private void RemoveSelected(Object sender, EventArgs e)
        {
            MoveSelected(SongsInLibrary, SongsAvailable);
            SortListViewGroups(SongsAvailable);
        }

        private void AddAll(Object sender, EventArgs e)
        {
            foreach (ListViewItem item in SongsAvailable.Items)
            {
                SongsInLibrary.Items.Add(new ListViewItem(new[] { item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text }));
            }
        }

        private void RemoveAll(object sender, EventArgs e)
        {
            SongsInLibrary.Items.Clear();
        }

        private void MoveSelected(ListView from, ListView to)
        {
            ListViewGroup ListGroup;
            foreach (ListViewItem item in from.SelectedItems)
            {
                var groupHeader = item.SubItems[0].Text.Substring(0, 1);
                // Get the first group that matches, or null if it's not there
                ListGroup = to.Groups.Cast<ListViewGroup>()
                    .FirstOrDefault(g => g.Header == groupHeader);

                // If it's not there, create it and add it
                if (ListGroup == null)
                {
                    ListGroup = new ListViewGroup(groupHeader);
                    to.Groups.Add(ListGroup);
                }

                // Move the song to the goup and add the song to the library
                from.Items.Remove(item);
                item.Group = ListGroup;
                to.Items.Add(item);
            }
        }

        private void SortListViewGroups(ListView listView)
        {
            ListViewGroup[] groups = new ListViewGroup[listView.Groups.Count];
            listView.Groups.CopyTo(groups, 0);
            Array.Sort(groups, new ListViewGroupComparer());
            listView.BeginUpdate();
            listView.Groups.Clear();
            listView.Groups.AddRange(groups);
            listView.EndUpdate();
        }
    }
}
