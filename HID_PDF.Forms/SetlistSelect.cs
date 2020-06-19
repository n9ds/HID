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
    public partial class SetlistSelect : Form
    {
        public int SelectedSetlistId { get; set; }
        public SongLibrary SongLibrary { get; set; }
        public SongSelect.Modes Mode { get; set; }
  
        public event EventHandler<SetlistSelectedEventArgs> SetlistSelected;

        public SetlistSelect()
        {
            SongLibrary = new SongLibrary();
            InitializeComponent();
            LoadSetlistList();
        }

        private void LoadSetlistList()
        {
            ListViewGroup ListGroup = new ListViewGroup("A");
            String CurrentGroup = "";
            List<Setlist> Setlists = SongLibrary.Setlists.OrderBy(S => S.Title).ToList();
            ListView SetlistsList = SetlistList;
            SetlistsList.Items.Clear();
            SetlistsList.Groups.Clear();
            foreach (Setlist s in Setlists)
            {
                if (!s.Title.Substring(0,1).Equals(CurrentGroup))
                {
                    CurrentGroup = s.Title.Substring(0, 1);
                    ListGroup = new ListViewGroup(CurrentGroup);
                    SetlistsList.Groups.Add(ListGroup);
                }
                SetlistsList.Items.Add(new ListViewItem(new[] { s.Title, s.Band, s.Id.ToString() }, ListGroup));
            }
        }

        private void OpenSetlist(object sender, EventArgs e)
        {
            SetlistSelectedEventArgs s = new SetlistSelectedEventArgs();
            var lastSubItem = SetlistList.SelectedItems[0].SubItems.Count - 1;
            var id = int.Parse(SetlistList.SelectedItems[0].SubItems[lastSubItem].Text);
            s.Mode = (int)SongSelect.Modes.Open;
            s.SetlistId = id;
            //s.Filename = SongSetlist.Libraries.Where(T => T.Id == id).FirstOrDefault().Filepath;
            OnSetlistSelected(s);
            Close();
        }

        private void CreateSetlist(object sender, EventArgs e)
        {
            SetlistMaintenance dlg = new SetlistMaintenance();
            dlg.ShowDialog();
            LoadSetlistList();
            EnableButtons(sender, e);
        }

        private void EditSetlist(object sender, EventArgs e)
        {
            var lastSubItem = SetlistList.SelectedItems[0].SubItems.Count - 1;
            var SetlistId = int.Parse(SetlistList.SelectedItems[0].SubItems[lastSubItem].Text);
            SetlistMaintenance dlg = new SetlistMaintenance(SetlistId, SongSelect.Modes.Edit);
            dlg.ShowDialog();
            LoadSetlistList();
            EnableButtons(sender, e);
        }

        private void DeleteSetlist(object sender, EventArgs e)
        {
            var lastSubItem = SetlistList.SelectedItems[0].SubItems.Count - 1;
            var SetlistId = int.Parse(SetlistList.SelectedItems[0].SubItems[lastSubItem].Text);
            Setlist setlist = SongLibrary.Setlists.Where(l => l.Id == SetlistId).FirstOrDefault();
            var rc = MessageBox.Show("Are you sure you want to delete the library '" + setlist.Title + "'?", "Delete Setlist", MessageBoxButtons.YesNoCancel);
            if (rc == DialogResult.Yes)
            {
                SongLibrary.Setlists.Remove(setlist);
            }
            //SetlistCreateEditDelete dlg = new SetlistCreateEditDelete(SetlistId, SongSelect.Modes.Delete);
            //dlg.ShowDialog();
            //LoadSetlistList();
            EnableButtons(sender, e);
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void OnSetlistSelected(SetlistSelectedEventArgs e )
        {
            var lastSubItem = SetlistList.SelectedItems[0].SubItems.Count - 1;
            e.SetlistId = int.Parse(SetlistList.SelectedItems[0].SubItems[lastSubItem].Text);
            SetlistSelected(this, e);
        }

        private void EnableButtons(object sender, EventArgs e)
        {
            bool enableButtons = (SetlistList.SelectedItems.Count > 0);
            btnOpenSetlist.Enabled = enableButtons;
            btnEditSetlist.Enabled = enableButtons;
            btnDeleteSetlist.Enabled = enableButtons;
        }
    }
}
