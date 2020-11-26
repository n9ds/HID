namespace HID_PDF.Forms
{
    partial class SongMaintenance
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
            this.SongTitle = new System.Windows.Forms.TextBox();
            this.SongArtist = new System.Windows.Forms.TextBox();
            this.SongFilename = new System.Windows.Forms.TextBox();
            this.SongKeyIsMinor = new System.Windows.Forms.CheckBox();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.lblSongArtist = new System.Windows.Forms.Label();
            this.lblSongInstrument = new System.Windows.Forms.Label();
            this.lblSongKey = new System.Windows.Forms.Label();
            this.lblSongFirstNote = new System.Windows.Forms.Label();
            this.SongKey = new System.Windows.Forms.ListBox();
            this.SongInstrument = new System.Windows.Forms.ListBox();
            this.SongFirstNote = new System.Windows.Forms.ListBox();
            this.lblSongFilename = new System.Windows.Forms.Label();
            this.SongFileBrowse = new System.Windows.Forms.Button();
            this.lblFileType = new System.Windows.Forms.Label();
            this.FileType = new System.Windows.Forms.ListBox();
            this.SongSave = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SongId = new System.Windows.Forms.TextBox();
            this.SongDelete = new System.Windows.Forms.Button();
            this.Libraries = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SongTitle
            // 
            this.SongTitle.CausesValidation = false;
            this.SongTitle.Location = new System.Drawing.Point(121, 66);
            this.SongTitle.Name = "SongTitle";
            this.SongTitle.Size = new System.Drawing.Size(120, 20);
            this.SongTitle.TabIndex = 2;
            // 
            // SongArtist
            // 
            this.SongArtist.CausesValidation = false;
            this.SongArtist.Location = new System.Drawing.Point(121, 92);
            this.SongArtist.Name = "SongArtist";
            this.SongArtist.Size = new System.Drawing.Size(120, 20);
            this.SongArtist.TabIndex = 3;
            // 
            // SongFilename
            // 
            this.SongFilename.Location = new System.Drawing.Point(121, 40);
            this.SongFilename.Name = "SongFilename";
            this.SongFilename.Size = new System.Drawing.Size(347, 20);
            this.SongFilename.TabIndex = 1;
            // 
            // SongKeyIsMinor
            // 
            this.SongKeyIsMinor.AutoSize = true;
            this.SongKeyIsMinor.Location = new System.Drawing.Point(248, 152);
            this.SongKeyIsMinor.Name = "SongKeyIsMinor";
            this.SongKeyIsMinor.Size = new System.Drawing.Size(52, 17);
            this.SongKeyIsMinor.TabIndex = 5;
            this.SongKeyIsMinor.Text = "Minor";
            this.SongKeyIsMinor.UseVisualStyleBackColor = true;
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.AutoSize = true;
            this.lblSongTitle.Location = new System.Drawing.Point(83, 69);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(27, 13);
            this.lblSongTitle.TabIndex = 3;
            this.lblSongTitle.Text = "Title";
            // 
            // lblSongArtist
            // 
            this.lblSongArtist.AutoSize = true;
            this.lblSongArtist.Location = new System.Drawing.Point(83, 92);
            this.lblSongArtist.Name = "lblSongArtist";
            this.lblSongArtist.Size = new System.Drawing.Size(30, 13);
            this.lblSongArtist.TabIndex = 4;
            this.lblSongArtist.Text = "Artist";
            // 
            // lblSongInstrument
            // 
            this.lblSongInstrument.AutoSize = true;
            this.lblSongInstrument.Location = new System.Drawing.Point(59, 119);
            this.lblSongInstrument.Name = "lblSongInstrument";
            this.lblSongInstrument.Size = new System.Drawing.Size(56, 13);
            this.lblSongInstrument.TabIndex = 5;
            this.lblSongInstrument.Text = "Instrument";
            // 
            // lblSongKey
            // 
            this.lblSongKey.AutoSize = true;
            this.lblSongKey.Location = new System.Drawing.Point(85, 152);
            this.lblSongKey.Name = "lblSongKey";
            this.lblSongKey.Size = new System.Drawing.Size(25, 13);
            this.lblSongKey.TabIndex = 6;
            this.lblSongKey.Text = "Key";
            // 
            // lblSongFirstNote
            // 
            this.lblSongFirstNote.AutoSize = true;
            this.lblSongFirstNote.Location = new System.Drawing.Point(63, 188);
            this.lblSongFirstNote.Name = "lblSongFirstNote";
            this.lblSongFirstNote.Size = new System.Drawing.Size(52, 13);
            this.lblSongFirstNote.TabIndex = 7;
            this.lblSongFirstNote.Text = "First Note";
            // 
            // SongKey
            // 
            this.SongKey.FormattingEnabled = true;
            this.SongKey.Items.AddRange(new object[] {
            "Ab",
            "A",
            "B",
            "Bb",
            "C",
            "C#",
            "Db",
            "D",
            "Eb",
            "E",
            "F",
            "F#",
            "G",
            ""});
            this.SongKey.Location = new System.Drawing.Point(122, 152);
            this.SongKey.Name = "SongKey";
            this.SongKey.Size = new System.Drawing.Size(120, 30);
            this.SongKey.TabIndex = 5;
            // 
            // SongInstrument
            // 
            this.SongInstrument.CausesValidation = false;
            this.SongInstrument.FormattingEnabled = true;
            this.SongInstrument.Items.AddRange(new object[] {
            "Bass (4 or 6 string)",
            "Bass (4 string)",
            "Bass (6 string)",
            "TSax",
            "ASax",
            "Clarinet",
            "Piano",
            "Guitar",
            "Ukulele",
            "Flute"});
            this.SongInstrument.Location = new System.Drawing.Point(121, 116);
            this.SongInstrument.Name = "SongInstrument";
            this.SongInstrument.Size = new System.Drawing.Size(120, 30);
            this.SongInstrument.TabIndex = 4;
            // 
            // SongFirstNote
            // 
            this.SongFirstNote.FormattingEnabled = true;
            this.SongFirstNote.Items.AddRange(new object[] {
            "Ab",
            "A",
            "B",
            "Bb",
            "C",
            "C#",
            "Db",
            "D",
            "Eb",
            "E",
            "F",
            "F#",
            "G",
            ""});
            this.SongFirstNote.Location = new System.Drawing.Point(122, 188);
            this.SongFirstNote.Name = "SongFirstNote";
            this.SongFirstNote.Size = new System.Drawing.Size(120, 30);
            this.SongFirstNote.TabIndex = 6;
            // 
            // lblSongFilename
            // 
            this.lblSongFilename.AutoSize = true;
            this.lblSongFilename.Location = new System.Drawing.Point(64, 41);
            this.lblSongFilename.Name = "lblSongFilename";
            this.lblSongFilename.Size = new System.Drawing.Size(52, 13);
            this.lblSongFilename.TabIndex = 14;
            this.lblSongFilename.Text = "File name";
            // 
            // SongFileBrowse
            // 
            this.SongFileBrowse.Location = new System.Drawing.Point(477, 38);
            this.SongFileBrowse.Name = "SongFileBrowse";
            this.SongFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.SongFileBrowse.TabIndex = 15;
            this.SongFileBrowse.Text = "Browse";
            this.SongFileBrowse.UseVisualStyleBackColor = true;
            this.SongFileBrowse.Click += new System.EventHandler(this.SelectFile);
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(64, 226);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(50, 13);
            this.lblFileType.TabIndex = 16;
            this.lblFileType.Text = "File Type";
            // 
            // FileType
            // 
            this.FileType.FormattingEnabled = true;
            this.FileType.Items.AddRange(new object[] {
            "PDF",
            "JPG",
            "PNG"});
            this.FileType.Location = new System.Drawing.Point(122, 226);
            this.FileType.Name = "FileType";
            this.FileType.Size = new System.Drawing.Size(120, 30);
            this.FileType.TabIndex = 7;
            // 
            // SongSave
            // 
            this.SongSave.Location = new System.Drawing.Point(116, 337);
            this.SongSave.Name = "SongSave";
            this.SongSave.Size = new System.Drawing.Size(75, 23);
            this.SongSave.TabIndex = 9;
            this.SongSave.Text = "Save";
            this.SongSave.UseVisualStyleBackColor = true;
            this.SongSave.Click += new System.EventHandler(this.Save);
            // 
            // Cancel
            // 
            this.Cancel.CausesValidation = false;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(197, 337);
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
            this.label1.Location = new System.Drawing.Point(94, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Id";
            // 
            // SongId
            // 
            this.SongId.Location = new System.Drawing.Point(121, 12);
            this.SongId.Name = "SongId";
            this.SongId.ReadOnly = true;
            this.SongId.Size = new System.Drawing.Size(100, 20);
            this.SongId.TabIndex = 21;
            // 
            // SongDelete
            // 
            this.SongDelete.Location = new System.Drawing.Point(116, 337);
            this.SongDelete.Name = "SongDelete";
            this.SongDelete.Size = new System.Drawing.Size(75, 23);
            this.SongDelete.TabIndex = 23;
            this.SongDelete.Text = "Delete";
            this.SongDelete.UseVisualStyleBackColor = true;
            this.SongDelete.Visible = false;
            this.SongDelete.Click += new System.EventHandler(this.Delete);
            // 
            // Libraries
            // 
            this.Libraries.FormattingEnabled = true;
            this.Libraries.Location = new System.Drawing.Point(122, 263);
            this.Libraries.Name = "Libraries";
            this.Libraries.ScrollAlwaysVisible = true;
            this.Libraries.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Libraries.Size = new System.Drawing.Size(178, 69);
            this.Libraries.TabIndex = 24;
            // 
            // SongMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(623, 384);
            this.Controls.Add(this.Libraries);
            this.Controls.Add(this.SongDelete);
            this.Controls.Add(this.SongId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SongSave);
            this.Controls.Add(this.FileType);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.SongFileBrowse);
            this.Controls.Add(this.lblSongFilename);
            this.Controls.Add(this.SongFirstNote);
            this.Controls.Add(this.SongInstrument);
            this.Controls.Add(this.SongKey);
            this.Controls.Add(this.lblSongFirstNote);
            this.Controls.Add(this.lblSongKey);
            this.Controls.Add(this.lblSongInstrument);
            this.Controls.Add(this.lblSongArtist);
            this.Controls.Add(this.lblSongTitle);
            this.Controls.Add(this.SongKeyIsMinor);
            this.Controls.Add(this.SongFilename);
            this.Controls.Add(this.SongArtist);
            this.Controls.Add(this.SongTitle);
            this.Name = "SongMaintenance";
            this.Text = "SongCreate";
            this.Resize += new System.EventHandler(this.RedrawChildren);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SongTitle;
        private System.Windows.Forms.TextBox SongArtist;
        private System.Windows.Forms.TextBox SongFilename;
        private System.Windows.Forms.CheckBox SongKeyIsMinor;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.Label lblSongArtist;
        private System.Windows.Forms.Label lblSongInstrument;
        private System.Windows.Forms.Label lblSongKey;
        private System.Windows.Forms.Label lblSongFirstNote;
        private System.Windows.Forms.ListBox SongKey;
        private System.Windows.Forms.ListBox SongInstrument;
        private System.Windows.Forms.ListBox SongFirstNote;
        private System.Windows.Forms.Label lblSongFilename;
        private System.Windows.Forms.Button SongFileBrowse;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.ListBox FileType;
        private System.Windows.Forms.Button SongSave;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SongId;
        private System.Windows.Forms.Button SongDelete;
        private System.Windows.Forms.ListBox Libraries;
    }
}