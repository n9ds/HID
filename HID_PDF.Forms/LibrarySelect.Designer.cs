namespace HID_PDF.Forms
{
    partial class LibrarySelect
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
            this.LibraryList = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LibraryId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenLibrary = new System.Windows.Forms.Button();
            this.btnEditLibrary = new System.Windows.Forms.Button();
            this.btnDeleteLibrary = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateLibrary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LibraryList
            // 
            this.LibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Description,
            this.LibraryId});
            this.LibraryList.FullRowSelect = true;
            this.LibraryList.HideSelection = false;
            this.LibraryList.Location = new System.Drawing.Point(35, 35);
            this.LibraryList.MultiSelect = false;
            this.LibraryList.Name = "LibraryList";
            this.LibraryList.Size = new System.Drawing.Size(513, 344);
            this.LibraryList.TabIndex = 0;
            this.LibraryList.UseCompatibleStateImageBehavior = false;
            this.LibraryList.View = System.Windows.Forms.View.Details;
            this.LibraryList.SelectedIndexChanged += new System.EventHandler(this.EnableButtons);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 131;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 370;
            // 
            // LibraryId
            // 
            this.LibraryId.Width = 0;
            // 
            // btnOpenLibrary
            // 
            this.btnOpenLibrary.Enabled = false;
            this.btnOpenLibrary.Location = new System.Drawing.Point(35, 402);
            this.btnOpenLibrary.Name = "btnOpenLibrary";
            this.btnOpenLibrary.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLibrary.TabIndex = 1;
            this.btnOpenLibrary.Text = "Open";
            this.btnOpenLibrary.UseVisualStyleBackColor = true;
            this.btnOpenLibrary.Click += new System.EventHandler(this.OpenLibrary);
            // 
            // btnEditLibrary
            // 
            this.btnEditLibrary.Enabled = false;
            this.btnEditLibrary.Location = new System.Drawing.Point(197, 402);
            this.btnEditLibrary.Name = "btnEditLibrary";
            this.btnEditLibrary.Size = new System.Drawing.Size(75, 23);
            this.btnEditLibrary.TabIndex = 2;
            this.btnEditLibrary.Text = "Edit";
            this.btnEditLibrary.UseVisualStyleBackColor = true;
            this.btnEditLibrary.Click += new System.EventHandler(this.EditLibrary);
            // 
            // btnDeleteLibrary
            // 
            this.btnDeleteLibrary.Enabled = false;
            this.btnDeleteLibrary.Location = new System.Drawing.Point(278, 402);
            this.btnDeleteLibrary.Name = "btnDeleteLibrary";
            this.btnDeleteLibrary.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLibrary.TabIndex = 3;
            this.btnDeleteLibrary.Text = "Delete";
            this.btnDeleteLibrary.UseVisualStyleBackColor = true;
            this.btnDeleteLibrary.Click += new System.EventHandler(this.DeleteLibrary);
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
            // btnCreateLibrary
            // 
            this.btnCreateLibrary.Location = new System.Drawing.Point(116, 402);
            this.btnCreateLibrary.Name = "btnCreateLibrary";
            this.btnCreateLibrary.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLibrary.TabIndex = 5;
            this.btnCreateLibrary.Text = "New";
            this.btnCreateLibrary.UseVisualStyleBackColor = true;
            this.btnCreateLibrary.Click += new System.EventHandler(this.CreateLibrary);
            // 
            // LibrarySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.btnCreateLibrary);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteLibrary);
            this.Controls.Add(this.btnEditLibrary);
            this.Controls.Add(this.btnOpenLibrary);
            this.Controls.Add(this.LibraryList);
            this.Name = "LibrarySelect";
            this.Text = "LibrarySelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LibraryList;
        private System.Windows.Forms.Button btnOpenLibrary;
        private System.Windows.Forms.Button btnEditLibrary;
        private System.Windows.Forms.Button btnDeleteLibrary;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader LibraryId;
        private System.Windows.Forms.Button btnCreateLibrary;
    }
}