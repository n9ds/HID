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
    public partial class LibrarySelect : Form
    {
        public int SelectedLibraryId { get; set; }
        public SongLibrary SongLibrary { get; set; }
        public SongSelect.Modes Mode { get; set; }
  
        public event EventHandler<LibrarySelectedEventArgs> LibrarySelected;

        public LibrarySelect()
        {
            SongLibrary = new SongLibrary();
            InitializeComponent();
            LoadLibraryList();
        }

        private void LoadLibraryList()
        {
            ListViewGroup ListGroup = new ListViewGroup("A");
            String CurrentGroup = "";
            List<Library> Libraries = SongLibrary.Libraries.OrderBy(S => S.Title).ToList();
            ListView LibrariesList = LibraryList;
            LibrariesList.Items.Clear();
            LibrariesList.Groups.Clear();
            foreach (Library s in Libraries)
            {
                if (!s.Title.Substring(0,1).Equals(CurrentGroup))
                {
                    CurrentGroup = s.Title.Substring(0, 1);
                    ListGroup = new ListViewGroup(CurrentGroup);
                    LibrariesList.Groups.Add(ListGroup);
                }
                LibrariesList.Items.Add(new ListViewItem(new[] { s.Title, s.Description, s.Id.ToString() }, ListGroup));
            }
        }

        private void OpenLibrary(object sender, EventArgs e)
        {
            LibrarySelectedEventArgs s = new LibrarySelectedEventArgs();
            var lastSubItem = LibraryList.SelectedItems[0].SubItems.Count - 1;
            var id = int.Parse(LibraryList.SelectedItems[0].SubItems[lastSubItem].Text);
            s.Mode = (int)SongSelect.Modes.Open;
            s.LibraryId = id;
            //s.Filename = SongLibrary.Libraries.Where(T => T.Id == id).FirstOrDefault().Filepath;
            OnLibrarySelected(s);
            Close();
        }

        private void CreateLibrary(object sender, EventArgs e)
        {
            LibraryMaintenance dlg = new LibraryMaintenance();
            dlg.ShowDialog();
            LoadLibraryList();
            EnableButtons(sender, e);
        }

        private void EditLibrary(object sender, EventArgs e)
        {
            var lastSubItem = LibraryList.SelectedItems[0].SubItems.Count - 1;
            var LibraryId = int.Parse(LibraryList.SelectedItems[0].SubItems[lastSubItem].Text);
            LibraryMaintenance dlg = new LibraryMaintenance(LibraryId, SongSelect.Modes.Edit);
            dlg.ShowDialog();
            LoadLibraryList();
            EnableButtons(sender, e);
        }

        private void DeleteLibrary(object sender, EventArgs e)
        {
            var lastSubItem = LibraryList.SelectedItems[0].SubItems.Count - 1;
            var LibraryId = int.Parse(LibraryList.SelectedItems[0].SubItems[lastSubItem].Text);
            Library library = SongLibrary.Libraries.Where(l => l.Id == LibraryId).FirstOrDefault();
            var rc = MessageBox.Show("Are you sure you want to delete the library '" + library.Title + "'?", "Delete Library", MessageBoxButtons.YesNoCancel);
            if (rc == DialogResult.Yes)
            {
                SongLibrary.Libraries.Remove(library);
            }
            //LibraryCreateEditDelete dlg = new LibraryCreateEditDelete(LibraryId, SongSelect.Modes.Delete);
            //dlg.ShowDialog();
            //LoadLibraryList();
            EnableButtons(sender, e);
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void OnLibrarySelected(LibrarySelectedEventArgs e )
        {
            var lastSubItem = LibraryList.SelectedItems[0].SubItems.Count - 1;
            e.LibraryId = int.Parse(LibraryList.SelectedItems[0].SubItems[lastSubItem].Text);
            LibrarySelected(this, e);
        }

        private void EnableButtons(object sender, EventArgs e)
        {
            bool enableButtons = (LibraryList.SelectedItems.Count > 0);
            btnOpenLibrary.Enabled = enableButtons;
            btnEditLibrary.Enabled = enableButtons;
            btnDeleteLibrary.Enabled = enableButtons;
        }
    }
}
