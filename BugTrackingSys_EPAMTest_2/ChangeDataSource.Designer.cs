namespace BugTrackingSys_EPAMTest_2
{
    partial class ChangeDataSource
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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Change = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_File_Path = new System.Windows.Forms.Label();
            this.lab_File_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя файла:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Путь:";
            // 
            // btn_Change
            // 
            this.btn_Change.Location = new System.Drawing.Point(125, 73);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(75, 23);
            this.btn_Change.TabIndex = 10;
            this.btn_Change.Text = "Изменить...";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(208, 73);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 9;
            this.btn_Ok.Text = "ОК";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 11;
            // 
            // lab_File_Path
            // 
            this.lab_File_Path.AutoSize = true;
            this.lab_File_Path.Location = new System.Drawing.Point(85, 36);
            this.lab_File_Path.Name = "lab_File_Path";
            this.lab_File_Path.Size = new System.Drawing.Size(0, 13);
            this.lab_File_Path.TabIndex = 12;
            // 
            // lab_File_Name
            // 
            this.lab_File_Name.AutoSize = true;
            this.lab_File_Name.Location = new System.Drawing.Point(85, 9);
            this.lab_File_Name.Name = "lab_File_Name";
            this.lab_File_Name.Size = new System.Drawing.Size(0, 13);
            this.lab_File_Name.TabIndex = 13;
            // 
            // ChangeDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 106);
            this.Controls.Add(this.lab_File_Name);
            this.Controls.Add(this.lab_File_Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeDataSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Источник данных";
            this.Shown += new System.EventHandler(this.ChangeDataSource_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_File_Path;
        private System.Windows.Forms.Label lab_File_Name;
    }
}