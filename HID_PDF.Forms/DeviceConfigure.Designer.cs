namespace HID_PDF.Forms
{
    partial class DeviceConfigure
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
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.Actions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Listen = new System.Windows.Forms.Button();
            this.lblConfiguredFlag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(34, 24);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(186, 17);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "Device Name Goes Here";
            // 
            // Actions
            // 
            this.Actions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Actions.FormattingEnabled = true;
            this.Actions.Location = new System.Drawing.Point(37, 73);
            this.Actions.Name = "Actions";
            this.Actions.Size = new System.Drawing.Size(173, 199);
            this.Actions.TabIndex = 1;
            this.Actions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawItemHandler);
            this.Actions.SelectedIndexChanged += new System.EventHandler(this.ActionSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Action";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(199, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(280, 310);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Cancel);
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(230, 114);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(75, 23);
            this.Listen.TabIndex = 7;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            // 
            // lblConfiguredFlag
            // 
            this.lblConfiguredFlag.AutoSize = true;
            this.lblConfiguredFlag.Location = new System.Drawing.Point(230, 95);
            this.lblConfiguredFlag.Name = "lblConfiguredFlag";
            this.lblConfiguredFlag.Size = new System.Drawing.Size(58, 13);
            this.lblConfiguredFlag.TabIndex = 8;
            this.lblConfiguredFlag.Text = "Configured";
            // 
            // DeviceConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 372);
            this.Controls.Add(this.lblConfiguredFlag);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Actions);
            this.Controls.Add(this.lblDeviceName);
            this.Name = "DeviceConfigure";
            this.Text = "DeviceConfigure";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.ListBox Actions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.Label lblConfiguredFlag;
    }
}