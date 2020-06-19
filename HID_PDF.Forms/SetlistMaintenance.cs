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
using static System.Windows.Forms.ListView;

namespace HID_PDF.Forms
{
    public partial class SetlistMaintenance : Form
    {
        public SongLibrary SongLibrary { get; set; }
        public Setlist Setlist { get; set; }
        public IList<SetlistEntry> Songs { get; set; }
        public SongSelect.Modes Mode { get; set; }
        public Dictionary<String, String> Errors { get; set; }
        public ListView SongsAtStart { get; set; }
        public bool CancelClicked { get; set; }

        public SetlistMaintenance()
        {
            SongLibrary = new SongLibrary();
            InitializeComponent();
            Errors = new Dictionary<String, String>();
            Setlist = null;
            SongsAtStart = new ListView();
            LoadBands();
            LoadSongs(null);
            Mode = SongSelect.Modes.Create;
        }

        public SetlistMaintenance(int SetlistId, SongSelect.Modes DlgMode)
            : this()
        {
            Setlist = SongLibrary.Setlists.Where(s => s.Id == SetlistId).FirstOrDefault();
            if (Setlist != null)
            {
                this.SetlistId.Text = Setlist.Id.ToString();
                SetlistTitle.Text = Setlist.Title;
                SetlistBand.SelectedItem = Setlist.Band;
            }
            LoadSongs(Setlist);
            Mode = DlgMode;
        }
        // TODO: Drag/Drop and/or Arrows for order
        private void LoadSongs(Setlist Setlist)
        {
            var AllSongs = SongLibrary.Songs.OrderBy(S => S.Title);
            // First load all the songs that are in all the libraries.
            // Then get the ones in the selected setlist and the ones that aren't.
            if (Setlist != null)
            {
                Setlist.SetlistEntries = SongLibrary.SetlistEntries.Where(s => s.Id == Setlist.Id).ToList();
                var SetlistSongs = Setlist.SetlistEntries.Select(s => s.Song).OrderBy(s => s.Title).AsEnumerable().ToList();
                var RemainingSongs = AllSongs.AsEnumerable().Except<Song>(SetlistSongs).ToList();
                LoadAvailableSongs(RemainingSongs, SongsAvailable);
            }
            else
            {
                LoadAvailableSongs(AllSongs.ToList(), SongsAvailable);
            }
            LoadSetlist(Setlist, SongsInSetlist);
            LoadSetlist(Setlist, SongsAtStart);
        }

        private void LoadAvailableSongs(IList<Song> songs, ListView listView)
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
                // The songs don't have a set order so we put in a dummy value.  Makes moving items back and forth easier.
                listView.Items.Add(new ListViewItem(new[] { s.Title, s.Artist, s.Instrument, s.Id.ToString(), "0" }, ListGroup));
            }
        }

        private void LoadSetlist(Setlist Setlist, ListView listView)
        {
            if (Setlist == null) 
            { 
                return;
            }
            foreach (SetlistEntry s in Setlist.SetlistEntries)
            {
                listView.Items.Add(new ListViewItem(new[] { s.Song.Title, s.Song.Artist, s.Song.Instrument, s.Song.Id.ToString(), s.SetOrder.ToString() }, s.SetOrder));
            }
        }

        private void LoadBands()
        {
            var Bands = SongLibrary.Bands.ToList();
            SetlistBand.DataSource = Bands;
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
                foreach (var errorMsg in Errors)
                {
                    ErrorMessages.Rows.Add(new[] { errorMsg.Key, errorMsg.Value });
                }
                ErrorMessages.Visible = true;
                return;
            }
            if (Mode == SongSelect.Modes.Create)
            {
                Setlist = new Setlist();
                Setlist.SetlistEntries = new List<SetlistEntry>();
            }
            Setlist.Title = SetlistTitle.Text;
            Setlist.Band = SetlistBand.SelectedValue.ToString();
            // Now gather the songs that are in the setlist.
            var Songs_Start = SongsAtStart.Items.Cast<ListViewItem>();
            var Songs_End = SongsInSetlist.Items.Cast<ListViewItem>();
            // Except() Items in the first set that don't appear in the second.
            var SongsToRemoveFromSetlist = Songs_Start.Except<ListViewItem>(Songs_End, new SetlistItemComparer()).ToList(); 
            var SongsToAddToSetlist = Songs_End.Except<ListViewItem>(Songs_Start, new SetlistItemComparer()).ToList();
            int SongId;
            foreach (ListViewItem SongToRemove in SongsToRemoveFromSetlist)
            {
                var rc = int.TryParse(SongToRemove.SubItems[3].Text, out SongId);
                if (rc)
                {
                    SongLibrary.SetlistEntries.Remove(SongLibrary.SetlistEntries.Where(s => s.Song.Id == SongId).FirstOrDefault());
                }
            }
            // Update the list of songs.
            foreach (ListViewItem SongToAdd in SongsToAddToSetlist)
            {
                var rc = int.TryParse(SongToAdd.SubItems[3].Text, out SongId);
                if (rc)
                {
                    int SetOrder;
                    int.TryParse(SongToAdd.SubItems[4].Text, out SetOrder);
                    Setlist.SetlistEntries.Add(new SetlistEntry(SongLibrary.Songs.Where(s => s.Id == SongId).FirstOrDefault(), SetOrder));
                }
            }
            if (Mode == SongSelect.Modes.Create)
            {
                SongLibrary.Setlists.Add(Setlist);
            }
            SongLibrary.SaveChanges();
            Close();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (Setlist == null)
            {
                MessageBox.Show("Not found");
            }
            else
            {
                DialogResult rc = MessageBox.Show("Delete " + Setlist.Title + "?", "Confirm Delete", MessageBoxButtons.YesNoCancel);
                if (rc == DialogResult.Yes)
                {
                    SongLibrary.Setlists.Remove(Setlist);
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
            // TODO: Iterate through a list of fields.
            // TODO: Make Validation configurable.
            bool IsFormValid = ValidateSongTextField("SetlistTitle");
            IsFormValid &= ValidateSongListBox("SetlistBand");
            return (IsFormValid);
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

        private void AddSelected(Object sender, EventArgs e)
        {
            MoveToSetlist(SongsAvailable, SongsInSetlist);
        }

        private void RemoveSelected(Object sender, EventArgs e)
        {
            RemoveFromSetlist(SongsAvailable, SongsInSetlist);
            SortListViewGroups(SongsAvailable);
        }

        private void AddAll(Object sender, EventArgs e)
        {
            foreach (ListViewItem item in SongsAvailable.Items)
            {
                SongsAvailable.Items.Remove(item);
                SongsInSetlist.Items.Add(item);
            }
        }

        private void RemoveAll(object sender, EventArgs e)
        {
            foreach (ListViewItem item in SongsInSetlist.Items)
            {
                ListViewGroup ListGroup;
                var groupHeader = item.SubItems[0].Text.Substring(0, 1);
                // Get the first group that matches, or null if it's not there
                ListGroup = SongsAvailable.Groups.Cast<ListViewGroup>()
                    .FirstOrDefault(g => g.Header == groupHeader);

                // If it's not there, create it and add it
                if (ListGroup == null)
                {
                    ListGroup = new ListViewGroup(groupHeader);
                    SongsAvailable.Groups.Add(ListGroup);
                }

                // Move the song to the goup and add the song to the Setlist
                SongsInSetlist.Items.Remove(item);
                item.Group = ListGroup;
                SongsAvailable.Items.Add(item);
            }
            SortListViewGroups(SongsAvailable);
        }

        private void MoveToSetlist(ListView SongsAvailable, ListView SongsInSetlist)
        {
            foreach (ListViewItem item in SongsAvailable.SelectedItems)
            {
                SongsAvailable.Items.Remove(item);
                SongsInSetlist.Items.Add(item);
            }
        }

        private void RemoveFromSetlist(ListView SongsAvailable, ListView SongsInSetlist)
        {
            ListViewGroup ListGroup;
            foreach (ListViewItem item in SongsInSetlist.SelectedItems)
            {
                var groupHeader = item.SubItems[0].Text.Substring(0, 1);
                // Get the first group that matches, or null if it's not there
                ListGroup = SongsAvailable.Groups.Cast<ListViewGroup>()
                    .FirstOrDefault(g => g.Header == groupHeader);

                // If it's not there, create it and add it
                if (ListGroup == null)
                {
                    ListGroup = new ListViewGroup(groupHeader);
                    SongsAvailable.Groups.Add(ListGroup);
                }

                // Move the song to the goup and add the song to the Setlist
                SongsInSetlist.Items.Remove(item);
                item.Group = ListGroup;
                SongsAvailable.Items.Add(item);
            }
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

                // Move the song to the goup and add the song to the Setlist
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

        private void MoveItemUp(object sender, EventArgs e)
        {
            //only moving one item at a time.
            var item = SongsInSetlist.SelectedItems[0];
            var NewPosition = SongsInSetlist.SelectedIndices[0] - 1;
            if (NewPosition >= 0)
            {
                SongsInSetlist.Items.Remove(item);
                SongsInSetlist.Items.Insert(NewPosition, item);
            }
        }

        private void MoveItemDown(object sender, EventArgs e)
        {
            var item = SongsInSetlist.SelectedItems[0];
            var NewPosition = SongsInSetlist.SelectedIndices[0] + 1;
            if (NewPosition < SongsInSetlist.Items.Count)
            {
                SongsInSetlist.Items.Remove(item);
                SongsInSetlist.Items.Insert(NewPosition, item);
            }
        }
    }
}
