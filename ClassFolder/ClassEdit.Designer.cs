namespace Roll_Call.ClassFolder
{
    partial class ClassEdit
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
            this.txtClassTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClassID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbTrack = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Title";
            // 
            // txtClassTitle
            // 
            this.txtClassTitle.Location = new System.Drawing.Point(91, 55);
            this.txtClassTitle.Name = "txtClassTitle";
            this.txtClassTitle.Size = new System.Drawing.Size(192, 22);
            this.txtClassTitle.TabIndex = 1;
            this.txtClassTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Class ID";
            // 
            // lblClassID
            // 
            this.lblClassID.AutoSize = true;
            this.lblClassID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassID.Location = new System.Drawing.Point(100, 19);
            this.lblClassID.Name = "lblClassID";
            this.lblClassID.Size = new System.Drawing.Size(100, 20);
            this.lblClassID.TabIndex = 5;
            this.lblClassID.Text = "Class Title";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(271, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbTrack
            // 
            this.cmbTrack.FormattingEnabled = true;
            this.cmbTrack.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cmbTrack.Location = new System.Drawing.Point(104, 83);
            this.cmbTrack.Name = "cmbTrack";
            this.cmbTrack.Size = new System.Drawing.Size(121, 24);
            this.cmbTrack.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Class Track";
            // 
            // ClassEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 184);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTrack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblClassID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClassTitle);
            this.Controls.Add(this.label1);
            this.Name = "ClassEdit";
            this.Text = "ClassEdit";
            this.Load += new System.EventHandler(this.ClassEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblClassID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbTrack;
        private System.Windows.Forms.Label label2;
    }
}