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
using HID_PDF;

namespace HID_PDF.Forms
{
    public partial class SongSelect : Form
    {
        public int SelectedSongId { get; set; }
        public SongLibrary SongLibrary { get; set; }
        public int? LibraryId { get; set; }
        public Modes Mode { get; set; }
        public enum Modes { Create,
                            Open,
                            Edit,
                            Delete};

        public event EventHandler<SongSelectedEventArgs> SongSelected;

        public SongSelect()
        {
            LibraryId = null;
            InitializeComponent();
            LoadSongList();
        }

        public SongSelect(int LibraryId)
        {
            this.LibraryId = LibraryId;
            SongLibrary = new SongLibrary();
            InitializeComponent();
            LoadSongList();
        }

        public void LoadSongList()
        {
            SongLibrary = new SongLibrary();
            ListViewGroup ListGroup = new ListViewGroup("A");
            String CurrentGroup = "";
            List<Song> Songs;
            if (LibraryId == null)
            {
                Songs = SongLibrary.Songs.OrderBy(S => S.Title).ToList();
            }
            else
            {
                Songs = SongLibrary.Libraries.Where(S => S.Id == LibraryId).
                    FirstOrDefault().
                    Songs.
                    OrderBy(S => S.Title).
                    ToList();
            }
            ListView songsList = SongList;
            songsList.Items.Clear();
            songsList.Groups.Clear();
            foreach (Song S in Songs)
            {
                if (!S.Title.Substring(0,1).Equals(CurrentGroup))
                {
                    CurrentGroup = S.Title.Substring(0, 1);
                    ListGroup = new ListViewGroup(CurrentGroup);
                    songsList.Groups.Add(ListGroup);
                }
                songsList.Items.Add(new ListViewItem(new[] { S.Title, S.Artist, S.Instrument, S.Id.ToString() }, ListGroup));
            }
        }

        private void OpenSong(object sender, EventArgs e)
        {
            SongSelectedEventArgs s = new SongSelectedEventArgs();
            var lastSubItem = SongList.SelectedItems[0].SubItems.Count - 1;
            var id = int.Parse(SongList.SelectedItems[0].SubItems[lastSubItem].Text);
            s.Mode = (int)Modes.Open;
            s.SongId = id;
            s.Filename = SongLibrary.Songs.Where(T => T.Id == id).FirstOrDefault().Filepath;
            OnSongSelected(s);
            Close();
        }

        private void CreateSong(object sender, EventArgs e)
        {
            var dlg = new SongMaintenance();
            dlg.ShowDialog();
            LoadSongList();
            EnableButtons(sender, e);
        }

        private void EditSong(object sender, EventArgs e)
        {
            var lastSubItem = SongList.SelectedItems[0].SubItems.Count - 1;
            var SongId = int.Parse(SongList.SelectedItems[0].SubItems[lastSubItem].Text);
            var dlg = new SongMaintenance(SongId, Modes.Edit);
            dlg.ShowDialog();
            LoadSongList();
            EnableButtons(sender, e);
        }

        private void DeleteSong(object sender, EventArgs e)
        {
            var lastSubItem = SongList.SelectedItems[0].SubItems.Count - 1;
            var SongId = int.Parse(SongList.SelectedItems[0].SubItems[lastSubItem].Text);
            var dlg = new SongMaintenance(SongId, Modes.Delete);
            dlg.ShowDialog();
            LoadSongList();
            EnableButtons(sender, e);
            //SongSelectedEventArgs s = new SongSelectedEventArgs();
            //var lastSubItem = SongList.SelectedItems[0].SubItems.Count - 1;
            //var id = int.Parse(SongList.SelectedItems[0].SubItems[lastSubItem].Text);
            //s.Mode = (int)Modes.Delete;
            //s.SongId = id;
            //s.Filename = SongLibrary.Songs.Where(T => T.Id == id).FirstOrDefault().Filepath;
            //OnSongSelected(s);
            ////Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void OnSongSelected(SongSelectedEventArgs e )
        {
            var lastSubItem = SongList.SelectedItems[0].SubItems.Count - 1;
            e.SongId = int.Parse(SongList.SelectedItems[0].SubItems[lastSubItem].Text);
            SongSelected(this, e);
        }

        private void EnableButtons(object sender, EventArgs e)
        {
            bool enableButtons = (SongList.SelectedItems.Count > 0);
            btnOpenSong.Enabled = enableButtons;
            btnEditSong.Enabled = enableButtons;
            btnDeleteSong.Enabled = enableButtons;
        }
    }
}
