namespace HID_PDF.Forms
{
    partial class SetlistSelect
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
            this.SetlistList = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetlistId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenSetlist = new System.Windows.Forms.Button();
            this.btnEditSetlist = new System.Windows.Forms.Button();
            this.btnDeleteSetlist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateSetlist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetlistList
            // 
            this.SetlistList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Description,
            this.SetlistId});
            this.SetlistList.FullRowSelect = true;
            this.SetlistList.HideSelection = false;
            this.SetlistList.Location = new System.Drawing.Point(35, 35);
            this.SetlistList.MultiSelect = false;
            this.SetlistList.Name = "SetlistList";
            this.SetlistList.Size = new System.Drawing.Size(513, 344);
            this.SetlistList.TabIndex = 0;
            this.SetlistList.UseCompatibleStateImageBehavior = false;
            this.SetlistList.View = System.Windows.Forms.View.Details;
            this.SetlistList.SelectedIndexChanged += new System.EventHandler(this.EnableButtons);
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
            // SetlistId
            // 
            this.SetlistId.Width = 0;
            // 
            // btnOpenSetlist
            // 
            this.btnOpenSetlist.Enabled = false;
            this.btnOpenSetlist.Location = new System.Drawing.Point(35, 402);
            this.btnOpenSetlist.Name = "btnOpenSetlist";
            this.btnOpenSetlist.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSetlist.TabIndex = 1;
            this.btnOpenSetlist.Text = "Open";
            this.btnOpenSetlist.UseVisualStyleBackColor = true;
            this.btnOpenSetlist.Click += new System.EventHandler(this.OpenSetlist);
            // 
            // btnEditSetlist
            // 
            this.btnEditSetlist.Enabled = false;
            this.btnEditSetlist.Location = new System.Drawing.Point(197, 402);
            this.btnEditSetlist.Name = "btnEditSetlist";
            this.btnEditSetlist.Size = new System.Drawing.Size(75, 23);
            this.btnEditSetlist.TabIndex = 2;
            this.btnEditSetlist.Text = "Edit";
            this.btnEditSetlist.UseVisualStyleBackColor = true;
            this.btnEditSetlist.Click += new System.EventHandler(this.EditSetlist);
            // 
            // btnDeleteSetlist
            // 
            this.btnDeleteSetlist.Enabled = false;
            this.btnDeleteSetlist.Location = new System.Drawing.Point(278, 402);
            this.btnDeleteSetlist.Name = "btnDeleteSetlist";
            this.btnDeleteSetlist.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSetlist.TabIndex = 3;
            this.btnDeleteSetlist.Text = "Delete";
            this.btnDeleteSetlist.UseVisualStyleBackColor = true;
            this.btnDeleteSetlist.Click += new System.EventHandler(this.DeleteSetlist);
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
            // btnCreateSetlist
            // 
            this.btnCreateSetlist.Location = new System.Drawing.Point(116, 402);
            this.btnCreateSetlist.Name = "btnCreateSetlist";
            this.btnCreateSetlist.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSetlist.TabIndex = 5;
            this.btnCreateSetlist.Text = "New";
            this.btnCreateSetlist.UseVisualStyleBackColor = true;
            this.btnCreateSetlist.Click += new System.EventHandler(this.CreateSetlist);
            // 
            // SetlistSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.btnCreateSetlist);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteSetlist);
            this.Controls.Add(this.btnEditSetlist);
            this.Controls.Add(this.btnOpenSetlist);
            this.Controls.Add(this.SetlistList);
            this.Name = "SetlistSelect";
            this.Text = "SetlistSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SetlistList;
        private System.Windows.Forms.Button btnOpenSetlist;
        private System.Windows.Forms.Button btnEditSetlist;
        private System.Windows.Forms.Button btnDeleteSetlist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader SetlistId;
        private System.Windows.Forms.Button btnCreateSetlist;
    }
}