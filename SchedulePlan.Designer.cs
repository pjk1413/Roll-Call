namespace Roll_Call
{
    partial class SchedulePlan
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
            this.txtClassesPerHour = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.txtStudents = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClasses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTeachers = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtClassSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClassesPerHour
            // 
            this.txtClassesPerHour.Location = new System.Drawing.Point(136, 12);
            this.txtClassesPerHour.Name = "txtClassesPerHour";
            this.txtClassesPerHour.Size = new System.Drawing.Size(100, 22);
            this.txtClassesPerHour.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Classes Per Hour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Student Errors";
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(136, 43);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(100, 22);
            this.txtErrors.TabIndex = 3;
            this.txtErrors.TextChanged += new System.EventHandler(this.txtErrors_TextChanged);
            // 
            // txtStudents
            // 
            this.txtStudents.Location = new System.Drawing.Point(136, 72);
            this.txtStudents.Name = "txtStudents";
            this.txtStudents.Size = new System.Drawing.Size(100, 22);
            this.txtStudents.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Students";
            // 
            // txtClasses
            // 
            this.txtClasses.Location = new System.Drawing.Point(136, 100);
            this.txtClasses.Name = "txtClasses";
            this.txtClasses.Size = new System.Drawing.Size(100, 22);
            this.txtClasses.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Classes";
            // 
            // txtTeachers
            // 
            this.txtTeachers.Location = new System.Drawing.Point(136, 128);
            this.txtTeachers.Name = "txtTeachers";
            this.txtTeachers.Size = new System.Drawing.Size(100, 22);
            this.txtTeachers.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Teachers";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 65);
            this.button1.TabIndex = 10;
            this.button1.Text = "Generate Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtClassSize
            // 
            this.txtClassSize.Location = new System.Drawing.Point(136, 156);
            this.txtClassSize.Name = "txtClassSize";
            this.txtClassSize.Size = new System.Drawing.Size(100, 22);
            this.txtClassSize.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Max Class Size";
            // 
            // SchedulePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 317);
            this.Controls.Add(this.txtClassSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTeachers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtClasses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStudents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClassesPerHour);
            this.Name = "SchedulePlan";
            this.Text = "SchedulePlan";
            this.Load += new System.EventHandler(this.SchedulePlan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClassesPerHour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.TextBox txtStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClasses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTeachers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtClassSize;
        private System.Windows.Forms.Label label6;
    }
}