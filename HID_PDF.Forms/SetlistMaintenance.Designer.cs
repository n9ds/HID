namespace HID_PDF.Forms
{
    partial class SetlistMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetlistMaintenance));
            this.SetlistTitle = new System.Windows.Forms.TextBox();
            this.lblSetlistTitle = new System.Windows.Forms.Label();
            this.lblSetlistDescription = new System.Windows.Forms.Label();
            this.SetlistSave = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SetlistId = new System.Windows.Forms.TextBox();
            this.ErrorMessages = new System.Windows.Forms.DataGridView();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongsAvailable = new System.Windows.Forms.ListView();
            this.SongTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Instrument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSongs = new System.Windows.Forms.Label();
            this.SongsInSetlist = new System.Windows.Forms.ListView();
            this.SelectedTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedInstrument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedSongId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedSetOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSongsInSetlist = new System.Windows.Forms.Label();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveSong = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.MoveUp = new System.Windows.Forms.Button();
            this.MoveDown = new System.Windows.Forms.Button();
            this.SetlistBand = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // SetlistTitle
            // 
            this.SetlistTitle.CausesValidation = false;
            this.SetlistTitle.Location = new System.Drawing.Point(119, 47);
            this.SetlistTitle.Name = "SetlistTitle";
            this.SetlistTitle.Size = new System.Drawing.Size(120, 20);
            this.SetlistTitle.TabIndex = 2;
            // 
            // lblSetlistTitle
            // 
            this.lblSetlistTitle.AutoSize = true;
            this.lblSetlistTitle.Location = new System.Drawing.Point(81, 50);
            this.lblSetlistTitle.Name = "lblSetlistTitle";
            this.lblSetlistTitle.Size = new System.Drawing.Size(27, 13);
            this.lblSetlistTitle.TabIndex = 3;
            this.lblSetlistTitle.Text = "Title";
            // 
            // lblSetlistDescription
            // 
            this.lblSetlistDescription.AutoSize = true;
            this.lblSetlistDescription.Location = new System.Drawing.Point(76, 76);
            this.lblSetlistDescription.Name = "lblSetlistDescription";
            this.lblSetlistDescription.Size = new System.Drawing.Size(32, 13);
            this.lblSetlistDescription.TabIndex = 4;
            this.lblSetlistDescription.Text = "Band";
            // 
            // SetlistSave
            // 
            this.SetlistSave.Location = new System.Drawing.Point(50, 364);
            this.SetlistSave.Name = "SetlistSave";
            this.SetlistSave.Size = new System.Drawing.Size(75, 23);
            this.SetlistSave.TabIndex = 9;
            this.SetlistSave.Text = "Save";
            this.SetlistSave.UseVisualStyleBackColor = true;
            this.SetlistSave.Click += new System.EventHandler(this.Save);
            // 
            // Cancel
            // 
            this.Cancel.CausesValidation = false;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(131, 364);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.CloseWindow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Id";
            // 
            // SetlistId
            // 
            this.SetlistId.Location = new System.Drawing.Point(119, 21);
            this.SetlistId.Name = "SetlistId";
            this.SetlistId.ReadOnly = true;
            this.SetlistId.Size = new System.Drawing.Size(100, 20);
            this.SetlistId.TabIndex = 21;
            // 
            // ErrorMessages
            // 
            this.ErrorMessages.AllowUserToAddRows = false;
            this.ErrorMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorMessages.CausesValidation = false;
            this.ErrorMessages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ErrorMessages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ErrorMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ErrorMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.ErrorMessage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ErrorMessages.DefaultCellStyle = dataGridViewCellStyle2;
            this.ErrorMessages.Location = new System.Drawing.Point(38, 393);
            this.ErrorMessages.Name = "ErrorMessages";
            this.ErrorMessages.ReadOnly = true;
            this.ErrorMessages.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ErrorMessages.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ErrorMessages.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ErrorMessages.Size = new System.Drawing.Size(529, 56);
            this.ErrorMessages.TabIndex = 22;
            this.ErrorMessages.Visible = false;
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "Field";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ErrorMessage.HeaderText = "Message";
            this.ErrorMessage.MinimumWidth = 75;
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ErrorMessage.Width = 75;
            // 
            // SongsAvailable
            // 
            this.SongsAvailable.AllowDrop = true;
            this.SongsAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SongTitle,
            this.SongArtist,
            this.Instrument,
            this.SongId,
            this.SetOrder});
            this.SongsAvailable.FullRowSelect = true;
            this.SongsAvailable.HideSelection = false;
            this.SongsAvailable.Location = new System.Drawing.Point(29, 134);
            this.SongsAvailable.Name = "SongsAvailable";
            this.SongsAvailable.Size = new System.Drawing.Size(230, 200);
            this.SongsAvailable.TabIndex = 24;
            this.SongsAvailable.UseCompatibleStateImageBehavior = false;
            this.SongsAvailable.View = System.Windows.Forms.View.Details;
            this.SongsAvailable.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.SongsAvailable_ItemDrag);
            this.SongsAvailable.DragDrop += new System.Windows.Forms.DragEventHandler(this.SongsAvailable_DragDrop);
            this.SongsAvailable.DragOver += new System.Windows.Forms.DragEventHandler(this.SongsAvailable_DragOver);
            // 
            // SongTitle
            // 
            this.SongTitle.Text = "Title";
            // 
            // SongArtist
            // 
            this.SongArtist.Text = "Artist";
            // 
            // Instrument
            // 
            this.Instrument.Text = "Instrument";
            // 
            // SongId
            // 
            this.SongId.Width = 0;
            // 
            // SetOrder
            // 
            this.SetOrder.Text = "Set Order";
            this.SetOrder.Width = 0;
            // 
            // lblSongs
            // 
            this.lblSongs.AutoSize = true;
            this.lblSongs.Location = new System.Drawing.Point(53, 115);
            this.lblSongs.Name = "lblSongs";
            this.lblSongs.Size = new System.Drawing.Size(83, 13);
            this.lblSongs.TabIndex = 25;
            this.lblSongs.Text = "Songs Available";
            // 
            // SongsInSetlist
            // 
            this.SongsInSetlist.AllowDrop = true;
            this.SongsInSetlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SelectedTitle,
            this.SelectedArtist,
            this.SelectedInstrument,
            this.SelectedSongId,
            this.SelectedSetOrder});
            this.SongsInSetlist.FullRowSelect = true;
            this.SongsInSetlist.HideSelection = false;
            this.SongsInSetlist.Location = new System.Drawing.Point(394, 134);
            this.SongsInSetlist.Name = "SongsInSetlist";
            this.SongsInSetlist.Size = new System.Drawing.Size(230, 200);
            this.SongsInSetlist.TabIndex = 26;
            this.SongsInSetlist.UseCompatibleStateImageBehavior = false;
            this.SongsInSetlist.View = System.Windows.Forms.View.Details;
            this.SongsInSetlist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.SongsInsSetlist_ItemDrag);
            this.SongsInSetlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.SongsInSetlist_DragDrop);
            this.SongsInSetlist.DragOver += new System.Windows.Forms.DragEventHandler(this.SongsInSetlist_DragOver);
            // 
            // SelectedTitle
            // 
            this.SelectedTitle.Text = "Title";
            // 
            // SelectedArtist
            // 
            this.SelectedArtist.Text = "Artist";
            // 
            // SelectedInstrument
            // 
            this.SelectedInstrument.Text = "Instrument";
            this.SelectedInstrument.Width = 0;
            // 
            // SelectedSongId
            // 
            this.SelectedSongId.Width = 0;
            // 
            // SelectedSetOrder
            // 
            this.SelectedSetOrder.Text = "Set Order";
            // 
            // lblSongsInSetlist
            // 
            this.lblSongsInSetlist.AutoSize = true;
            this.lblSongsInSetlist.Location = new System.Drawing.Point(391, 115);
            this.lblSongsInSetlist.Name = "lblSongsInSetlist";
            this.lblSongsInSetlist.Size = new System.Drawing.Size(79, 13);
            this.lblSongsInSetlist.TabIndex = 27;
            this.lblSongsInSetlist.Text = "Songs in Setlist";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(291, 246);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 28;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.RemoveAll);
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.Location = new System.Drawing.Point(291, 173);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSong.TabIndex = 29;
            this.btnRemoveSong.Text = "<";
            this.btnRemoveSong.UseVisualStyleBackColor = true;
            this.btnRemoveSong.Click += new System.EventHandler(this.RemoveSelected);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(291, 144);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(75, 23);
            this.btnAddSong.TabIndex = 30;
            this.btnAddSong.Text = ">";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.AddSelected);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(291, 217);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 23);
            this.btnAddAll.TabIndex = 31;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.AddAll);
            // 
            // MoveUp
            // 
            this.MoveUp.Image = ((System.Drawing.Image)(resources.GetObject("MoveUp.Image")));
            this.MoveUp.Location = new System.Drawing.Point(630, 156);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(25, 40);
            this.MoveUp.TabIndex = 32;
            this.MoveUp.UseVisualStyleBackColor = true;
            this.MoveUp.Click += new System.EventHandler(this.MoveItemUp);
            // 
            // MoveDown
            // 
            this.MoveDown.Image = ((System.Drawing.Image)(resources.GetObject("MoveDown.Image")));
            this.MoveDown.Location = new System.Drawing.Point(630, 217);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(25, 40);
            this.MoveDown.TabIndex = 33;
            this.MoveDown.UseVisualStyleBackColor = true;
            this.MoveDown.Click += new System.EventHandler(this.MoveItemDown);
            // 
            // SetlistBand
            // 
            this.SetlistBand.FormattingEnabled = true;
            this.SetlistBand.Location = new System.Drawing.Point(119, 76);
            this.SetlistBand.Name = "SetlistBand";
            this.SetlistBand.Size = new System.Drawing.Size(120, 30);
            this.SetlistBand.TabIndex = 34;
            // 
            // SetlistMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(672, 461);
            this.Controls.Add(this.SetlistBand);
            this.Controls.Add(this.MoveDown);
            this.Controls.Add(this.MoveUp);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.btnRemoveSong);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.lblSongsInSetlist);
            this.Controls.Add(this.SongsInSetlist);
            this.Controls.Add(this.lblSongs);
            this.Controls.Add(this.SongsAvailable);
            this.Controls.Add(this.SetlistTitle);
            this.Controls.Add(this.ErrorMessages);
            this.Controls.Add(this.SetlistId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SetlistSave);
            this.Controls.Add(this.lblSetlistDescription);
            this.Controls.Add(this.lblSetlistTitle);
            this.Name = "SetlistMaintenance";
            this.Text = "SetlistCreate";
            this.Resize += new System.EventHandler(this.RedrawChildren);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SetlistTitle;
        private System.Windows.Forms.Label lblSetlistTitle;
        private System.Windows.Forms.Label lblSetlistDescription;
        private System.Windows.Forms.Button SetlistSave;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SetlistId;
        private System.Windows.Forms.DataGridView ErrorMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
        private System.Windows.Forms.ListView SongsAvailable;
        private System.Windows.Forms.Label lblSongs;
        private System.Windows.Forms.ListView SongsInSetlist;
        private System.Windows.Forms.Label lblSongsInSetlist;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveSong;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ColumnHeader SongTitle;
        private System.Windows.Forms.ColumnHeader SongArtist;
        private System.Windows.Forms.ColumnHeader Instrument;
        private System.Windows.Forms.ColumnHeader SongId;
        private System.Windows.Forms.ColumnHeader SelectedTitle;
        private System.Windows.Forms.ColumnHeader SelectedArtist;
        private System.Windows.Forms.ColumnHeader SelectedInstrument;
        private System.Windows.Forms.ColumnHeader SelectedSongId;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.ColumnHeader SelectedSetOrder;
        private System.Windows.Forms.ColumnHeader SetOrder;
        private System.Windows.Forms.ListBox SetlistBand;
    }
}