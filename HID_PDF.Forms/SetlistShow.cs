using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HID_PDF.Data;
using HID_PDF.Domain;

namespace HID_PDF.Forms
{
    public partial class SetlistShow : Form
    {
        public int SetlistId { get; set; }
        public SongLibrary SongLibrary { get; set; }
        public event EventHandler<SongSelectedEventArgs> SongSelected;
        public enum Modes
        {
            Create,
            Open,
            Edit,
            Delete
        };

        public SetlistShow() : this(0)
        {
        }

        public SetlistShow(int SetlistId)
        {
            InitializeComponent();
            SongLibrary = new SongLibrary();
            this.SetlistId = SetlistId;
            if (SetlistId > 0)
            {
                LoadSetlist();
            }
        }
// TODO: Make the buttons do things
// TODO: Open PDF
// TODO: Make sure it's modeless.

        public void LoadSetlist()
        {
            Setlist setlist = SongLibrary.Setlists
                .Include("SetlistEntries.Song")
                .Where(S => S.Id == SetlistId).FirstOrDefault();
            if (setlist == null)
            {
                throw (new NotImplementedException());
            }
            List<SetlistEntry> Set = setlist.SetlistEntries.ToList().OrderBy(s => s.SetOrder).ToList();
            foreach (SetlistEntry sl in Set)
            {
                Song s = sl.Song;
                // The songs don't have a set order so we put in a dummy value.  Makes moving items back and forth easier.
                listView1.Items.Add(new ListViewItem(new[] { s.Title, s.Key, s.FirstNote, s.Id.ToString(), sl.SetOrder.ToString()}));
            }

        }

        private void NextSong(object sender, EventArgs e)
        {
            var NextSelection = 0;
            if (listView1.SelectedItems.Count == 0)
            {
                NextSelection = 0;
            }
            else
            {
                NextSelection = (listView1.SelectedIndices[0] < listView1.Items.Count - 1 ? listView1.SelectedIndices[0] + 1 : listView1.Items.Count - 1);
            }
            listView1.Items[NextSelection].Selected = true;
            listView1.Select();
        }

        private void PrevSong(object sender, EventArgs e)
        {
            var CurrentSelection = (listView1.SelectedIndices.Count == 0 ? 0 : listView1.SelectedIndices[0]);
            var PrevSelection = (CurrentSelection > 0  ? CurrentSelection - 1 : 0);
            listView1.Items[PrevSelection].Selected = true;
            listView1.Select();
        }

        private void OpenSong(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                var Song = listView1.SelectedItems[0].SubItems[3].Text;
                var SongId = int.Parse(Song);
                SongSelectedEventArgs songSelectedEventArgs = new SongSelectedEventArgs();
                songSelectedEventArgs.SongId = SongId;
                songSelectedEventArgs.Mode = (int)Modes.Open;
                songSelectedEventArgs.Filename = SongLibrary.Songs.Where(T => T.Id == SongId).FirstOrDefault().Filepath;
                SongSelected(this, songSelectedEventArgs);
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //protected virtual void OnSongSelected(SongSelectedEventArgs e)
        //{
        //    var lastSubItem = listView1.SelectedItems[0].SubItems.Count - 1;
        //    e.SongId = int.Parse(listView1.SelectedItems[0].SubItems[lastSubItem].Text);
        //    SongSelected(this, e);
        //}

    }
}
