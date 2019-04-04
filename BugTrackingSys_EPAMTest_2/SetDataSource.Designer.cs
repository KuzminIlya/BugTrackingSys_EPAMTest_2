namespace BugTrackingSys_EPAMTest_2
{
    partial class SetDataSource
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
            this.txtBx_Path = new System.Windows.Forms.TextBox();
            this.btn_SelectPath = new System.Windows.Forms.Button();
            this.chckbx_NewFile = new System.Windows.Forms.CheckBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.filedlg_OpenDataSource = new System.Windows.Forms.OpenFileDialog();
            this.foldbrowsdlg_DataSourcePath = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBx_FileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь";
            // 
            // txtBx_Path
            // 
            this.txtBx_Path.Location = new System.Drawing.Point(49, 18);
            this.txtBx_Path.Name = "txtBx_Path";
            this.txtBx_Path.Size = new System.Drawing.Size(379, 20);
            this.txtBx_Path.TabIndex = 1;
            // 
            // btn_SelectPath
            // 
            this.btn_SelectPath.Location = new System.Drawing.Point(434, 16);
            this.btn_SelectPath.Name = "btn_SelectPath";
            this.btn_SelectPath.Size = new System.Drawing.Size(57, 23);
            this.btn_SelectPath.TabIndex = 2;
            this.btn_SelectPath.Text = "...";
            this.btn_SelectPath.UseVisualStyleBackColor = true;
            this.btn_SelectPath.Click += new System.EventHandler(this.Btn_SelectPath_Click);
            // 
            // chckbx_NewFile
            // 
            this.chckbx_NewFile.AutoSize = true;
            this.chckbx_NewFile.Location = new System.Drawing.Point(325, 44);
            this.chckbx_NewFile.Name = "chckbx_NewFile";
            this.chckbx_NewFile.Size = new System.Drawing.Size(103, 17);
            this.chckbx_NewFile.TabIndex = 4;
            this.chckbx_NewFile.Text = "Создать новый";
            this.chckbx_NewFile.UseVisualStyleBackColor = true;
            this.chckbx_NewFile.CheckedChanged += new System.EventHandler(this.Chckbx_NewFile_CheckedChanged);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(416, 75);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "ОК";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(335, 75);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // filedlg_OpenDataSource
            // 
            this.filedlg_OpenDataSource.FileName = "*.db";
            this.filedlg_OpenDataSource.Filter = "(*.db)|*.db";
            // 
            // txtBx_FileName
            // 
            this.txtBx_FileName.Enabled = false;
            this.txtBx_FileName.Location = new System.Drawing.Point(49, 41);
            this.txtBx_FileName.Name = "txtBx_FileName";
            this.txtBx_FileName.Size = new System.Drawing.Size(270, 20);
            this.txtBx_FileName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Имя";
            // 
            // SetDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 106);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBx_FileName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.chckbx_NewFile);
            this.Controls.Add(this.btn_SelectPath);
            this.Controls.Add(this.txtBx_Path);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetDataSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор источника данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBx_Path;
        private System.Windows.Forms.Button btn_SelectPath;
        private System.Windows.Forms.CheckBox chckbx_NewFile;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.OpenFileDialog filedlg_OpenDataSource;
        private System.Windows.Forms.FolderBrowserDialog foldbrowsdlg_DataSourcePath;
        private System.Windows.Forms.TextBox txtBx_FileName;
        private System.Windows.Forms.Label label2;
    }
}