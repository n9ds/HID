namespace HID_PDF.Forms
{
    partial class LibraryMaintenance
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
            this.LibraryTitle = new System.Windows.Forms.TextBox();
            this.LibraryDescription = new System.Windows.Forms.TextBox();
            this.lblLibraryTitle = new System.Windows.Forms.Label();
            this.lblLibraryDescription = new System.Windows.Forms.Label();
            this.LibrarySave = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LibraryId = new System.Windows.Forms.TextBox();
            this.ErrorMessages = new System.Windows.Forms.DataGridView();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongsAvailable = new System.Windows.Forms.ListView();
            this.SongTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Instrument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSongs = new System.Windows.Forms.Label();
            this.SongsInLibrary = new System.Windows.Forms.ListView();
            this.SelectedTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedInstrument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedSongId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSongsInLibrary = new System.Windows.Forms.Label();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveSong = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // LibraryTitle
            // 
            this.LibraryTitle.CausesValidation = false;
            this.LibraryTitle.Location = new System.Drawing.Point(119, 47);
            this.LibraryTitle.Name = "LibraryTitle";
            this.LibraryTitle.Size = new System.Drawing.Size(120, 20);
            this.LibraryTitle.TabIndex = 2;
            // 
            // LibraryDescription
            // 
            this.LibraryDescription.CausesValidation = false;
            this.LibraryDescription.Location = new System.Drawing.Point(119, 73);
            this.LibraryDescription.Name = "LibraryDescription";
            this.LibraryDescription.Size = new System.Drawing.Size(120, 20);
            this.LibraryDescription.TabIndex = 3;
            // 
            // lblLibraryTitle
            // 
            this.lblLibraryTitle.AutoSize = true;
            this.lblLibraryTitle.Location = new System.Drawing.Point(81, 50);
            this.lblLibraryTitle.Name = "lblLibraryTitle";
            this.lblLibraryTitle.Size = new System.Drawing.Size(27, 13);
            this.lblLibraryTitle.TabIndex = 3;
            this.lblLibraryTitle.Text = "Title";
            // 
            // lblLibraryDescription
            // 
            this.lblLibraryDescription.AutoSize = true;
            this.lblLibraryDescription.Location = new System.Drawing.Point(48, 73);
            this.lblLibraryDescription.Name = "lblLibraryDescription";
            this.lblLibraryDescription.Size = new System.Drawing.Size(60, 13);
            this.lblLibraryDescription.TabIndex = 4;
            this.lblLibraryDescription.Text = "Description";
            // 
            // LibrarySave
            // 
            this.LibrarySave.Location = new System.Drawing.Point(50, 364);
            this.LibrarySave.Name = "LibrarySave";
            this.LibrarySave.Size = new System.Drawing.Size(75, 23);
            this.LibrarySave.TabIndex = 9;
            this.LibrarySave.Text = "Save";
            this.LibrarySave.UseVisualStyleBackColor = true;
            this.LibrarySave.Click += new System.EventHandler(this.Save);
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
            // LibraryId
            // 
            this.LibraryId.Location = new System.Drawing.Point(119, 21);
            this.LibraryId.Name = "LibraryId";
            this.LibraryId.ReadOnly = true;
            this.LibraryId.Size = new System.Drawing.Size(100, 20);
            this.LibraryId.TabIndex = 21;
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
            this.SongsAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SongTitle,
            this.SongArtist,
            this.Instrument,
            this.SongId});
            this.SongsAvailable.FullRowSelect = true;
            this.SongsAvailable.HideSelection = false;
            this.SongsAvailable.Location = new System.Drawing.Point(29, 134);
            this.SongsAvailable.Name = "SongsAvailable";
            this.SongsAvailable.Size = new System.Drawing.Size(295, 200);
            this.SongsAvailable.TabIndex = 24;
            this.SongsAvailable.UseCompatibleStateImageBehavior = false;
            this.SongsAvailable.View = System.Windows.Forms.View.Details;
            // 
            // SongTitle
            // 
            this.SongTitle.Text = "Title";
            this.SongTitle.Width = 100;
            // 
            // SongArtist
            // 
            this.SongArtist.Text = "Artist";
            this.SongArtist.Width = 100;
            // 
            // Instrument
            // 
            this.Instrument.Text = "Instrument";
            this.Instrument.Width = 100;
            // 
            // SongId
            // 
            this.SongId.Width = 0;
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
            // SongsInLibrary
            // 
            this.SongsInLibrary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SelectedTitle,
            this.SelectedArtist,
            this.SelectedInstrument,
            this.SelectedSongId});
            this.SongsInLibrary.FullRowSelect = true;
            this.SongsInLibrary.HideSelection = false;
            this.SongsInLibrary.Location = new System.Drawing.Point(446, 134);
            this.SongsInLibrary.Name = "SongsInLibrary";
            this.SongsInLibrary.Size = new System.Drawing.Size(295, 200);
            this.SongsInLibrary.TabIndex = 26;
            this.SongsInLibrary.UseCompatibleStateImageBehavior = false;
            this.SongsInLibrary.View = System.Windows.Forms.View.Details;
            // 
            // SelectedTitle
            // 
            this.SelectedTitle.Text = "Title";
            this.SelectedTitle.Width = 100;
            // 
            // SelectedArtist
            // 
            this.SelectedArtist.Text = "Artist";
            this.SelectedArtist.Width = 100;
            // 
            // SelectedInstrument
            // 
            this.SelectedInstrument.Text = "Instrument";
            this.SelectedInstrument.Width = 100;
            // 
            // SelectedSongId
            // 
            this.SelectedSongId.Width = 0;
            // 
            // lblSongsInLibrary
            // 
            this.lblSongsInLibrary.AutoSize = true;
            this.lblSongsInLibrary.Location = new System.Drawing.Point(391, 115);
            this.lblSongsInLibrary.Name = "lblSongsInLibrary";
            this.lblSongsInLibrary.Size = new System.Drawing.Size(82, 13);
            this.lblSongsInLibrary.TabIndex = 27;
            this.lblSongsInLibrary.Text = "Songs in Library";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(346, 243);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 28;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.RemoveAll);
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.Location = new System.Drawing.Point(346, 170);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSong.TabIndex = 29;
            this.btnRemoveSong.Text = "<";
            this.btnRemoveSong.UseVisualStyleBackColor = true;
            this.btnRemoveSong.Click += new System.EventHandler(this.RemoveSelected);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(346, 141);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(75, 23);
            this.btnAddSong.TabIndex = 30;
            this.btnAddSong.Text = ">";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.AddSelected);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(346, 214);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 23);
            this.btnAddAll.TabIndex = 31;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.AddAll);
            // 
            // LibraryMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(777, 461);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.btnRemoveSong);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.lblSongsInLibrary);
            this.Controls.Add(this.SongsInLibrary);
            this.Controls.Add(this.lblSongs);
            this.Controls.Add(this.SongsAvailable);
            this.Controls.Add(this.LibraryTitle);
            this.Controls.Add(this.LibraryDescription);
            this.Controls.Add(this.ErrorMessages);
            this.Controls.Add(this.LibraryId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.LibrarySave);
            this.Controls.Add(this.lblLibraryDescription);
            this.Controls.Add(this.lblLibraryTitle);
            this.Name = "LibraryMaintenance";
            this.Text = "LibraryCreate";
            this.Resize += new System.EventHandler(this.RedrawChildren);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LibraryTitle;
        private System.Windows.Forms.TextBox LibraryDescription;
        private System.Windows.Forms.Label lblLibraryTitle;
        private System.Windows.Forms.Label lblLibraryDescription;
        private System.Windows.Forms.Button LibrarySave;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LibraryId;
        private System.Windows.Forms.DataGridView ErrorMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
        private System.Windows.Forms.ListView SongsAvailable;
        private System.Windows.Forms.Label lblSongs;
        private System.Windows.Forms.ListView SongsInLibrary;
        private System.Windows.Forms.Label lblSongsInLibrary;
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
    }
}