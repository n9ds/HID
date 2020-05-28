namespace HID_PDF.Forms
{
    partial class SongSelect
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
            this.SongList = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Instrument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SongId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenSong = new System.Windows.Forms.Button();
            this.btnEditSong = new System.Windows.Forms.Button();
            this.btnDeleteSong = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateSong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SongList
            // 
            this.SongList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Artist,
            this.Instrument,
            this.SongId});
            this.SongList.FullRowSelect = true;
            this.SongList.HideSelection = false;
            this.SongList.Location = new System.Drawing.Point(35, 35);
            this.SongList.MultiSelect = false;
            this.SongList.Name = "SongList";
            this.SongList.Size = new System.Drawing.Size(513, 344);
            this.SongList.TabIndex = 0;
            this.SongList.UseCompatibleStateImageBehavior = false;
            this.SongList.View = System.Windows.Forms.View.Details;
            this.SongList.SelectedIndexChanged += new System.EventHandler(this.EnableButtons);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 131;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // Instrument
            // 
            this.Instrument.DisplayIndex = 3;
            this.Instrument.Text = "Instrument";
            // 
            // SongId
            // 
            this.SongId.DisplayIndex = 2;
            this.SongId.Width = 0;
            // 
            // btnOpenSong
            // 
            this.btnOpenSong.Enabled = false;
            this.btnOpenSong.Location = new System.Drawing.Point(35, 402);
            this.btnOpenSong.Name = "btnOpenSong";
            this.btnOpenSong.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSong.TabIndex = 1;
            this.btnOpenSong.Text = "Open";
            this.btnOpenSong.UseVisualStyleBackColor = true;
            this.btnOpenSong.Click += new System.EventHandler(this.OpenSong);
            // 
            // btnEditSong
            // 
            this.btnEditSong.Enabled = false;
            this.btnEditSong.Location = new System.Drawing.Point(197, 402);
            this.btnEditSong.Name = "btnEditSong";
            this.btnEditSong.Size = new System.Drawing.Size(75, 23);
            this.btnEditSong.TabIndex = 2;
            this.btnEditSong.Text = "Edit";
            this.btnEditSong.UseVisualStyleBackColor = true;
            this.btnEditSong.Click += new System.EventHandler(this.EditSong);
            // 
            // btnDeleteSong
            // 
            this.btnDeleteSong.Enabled = false;
            this.btnDeleteSong.Location = new System.Drawing.Point(278, 402);
            this.btnDeleteSong.Name = "btnDeleteSong";
            this.btnDeleteSong.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSong.TabIndex = 3;
            this.btnDeleteSong.Text = "Delete";
            this.btnDeleteSong.UseVisualStyleBackColor = true;
            this.btnDeleteSong.Click += new System.EventHandler(this.DeleteSong);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(359, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // btnCreateSong
            // 
            this.btnCreateSong.Location = new System.Drawing.Point(116, 402);
            this.btnCreateSong.Name = "btnCreateSong";
            this.btnCreateSong.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSong.TabIndex = 5;
            this.btnCreateSong.Text = "New";
            this.btnCreateSong.UseVisualStyleBackColor = true;
            this.btnCreateSong.Click += new System.EventHandler(this.CreateSong);
            // 
            // SongSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.btnCreateSong);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteSong);
            this.Controls.Add(this.btnEditSong);
            this.Controls.Add(this.btnOpenSong);
            this.Controls.Add(this.SongList);
            this.Name = "SongSelect";
            this.Text = "SongSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SongList;
        private System.Windows.Forms.Button btnOpenSong;
        private System.Windows.Forms.Button btnEditSong;
        private System.Windows.Forms.Button btnDeleteSong;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader SongId;
        private System.Windows.Forms.ColumnHeader Instrument;
        private System.Windows.Forms.Button btnCreateSong;
    }
}