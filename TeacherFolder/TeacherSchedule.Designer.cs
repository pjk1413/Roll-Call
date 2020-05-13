namespace Roll_Call
{
    partial class TeacherSchedule
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkListBoxPeriod = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "*Select Available Periods";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkListBoxPeriod
            // 
            this.chkListBoxPeriod.FormattingEnabled = true;
            this.chkListBoxPeriod.Items.AddRange(new object[] {
            "1st Period",
            "2nd Period",
            "3rd Period",
            "4th Period",
            "5th Period",
            "6th Period",
            "7th Period",
            "8th Period"});
            this.chkListBoxPeriod.Location = new System.Drawing.Point(15, 46);
            this.chkListBoxPeriod.Name = "chkListBoxPeriod";
            this.chkListBoxPeriod.Size = new System.Drawing.Size(101, 140);
            this.chkListBoxPeriod.TabIndex = 7;
            // 
            // TeacherSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 275);
            this.Controls.Add(this.chkListBoxPeriod);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TeacherSchedule";
            this.Text = "TeacherSchedule";
            this.Load += new System.EventHandler(this.TeacherSchedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox chkListBoxPeriod;
    }
}