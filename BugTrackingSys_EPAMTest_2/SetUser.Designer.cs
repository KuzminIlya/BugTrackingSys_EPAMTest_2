namespace BugTrackingSys_EPAMTest_2
{
    partial class SetUser
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbx_ID = new System.Windows.Forms.ComboBox();
            this.lab_Name = new System.Windows.Forms.Label();
            this.lab_Emp = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_SetUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Должность:";
            // 
            // cmbbx_ID
            // 
            this.cmbbx_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_ID.FormattingEnabled = true;
            this.cmbbx_ID.Location = new System.Drawing.Point(89, 6);
            this.cmbbx_ID.Name = "cmbbx_ID";
            this.cmbbx_ID.Size = new System.Drawing.Size(156, 21);
            this.cmbbx_ID.TabIndex = 3;
            this.cmbbx_ID.SelectedIndexChanged += new System.EventHandler(this.Cmbbx_ID_SelectedIndexChanged);
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(86, 35);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(0, 13);
            this.lab_Name.TabIndex = 4;
            // 
            // lab_Emp
            // 
            this.lab_Emp.AutoSize = true;
            this.lab_Emp.Location = new System.Drawing.Point(86, 62);
            this.lab_Emp.Name = "lab_Emp";
            this.lab_Emp.Size = new System.Drawing.Size(0, 13);
            this.lab_Emp.TabIndex = 5;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(89, 87);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btn_SetUser
            // 
            this.btn_SetUser.Location = new System.Drawing.Point(170, 87);
            this.btn_SetUser.Name = "btn_SetUser";
            this.btn_SetUser.Size = new System.Drawing.Size(75, 23);
            this.btn_SetUser.TabIndex = 7;
            this.btn_SetUser.Text = "Выбрать";
            this.btn_SetUser.UseVisualStyleBackColor = true;
            this.btn_SetUser.Click += new System.EventHandler(this.Btn_SetUser_Click);
            // 
            // SetUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 124);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_SetUser);
            this.Controls.Add(this.lab_Emp);
            this.Controls.Add(this.lab_Name);
            this.Controls.Add(this.cmbbx_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(275, 163);
            this.MinimumSize = new System.Drawing.Size(275, 163);
            this.Name = "SetUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор пользователя";
            this.Shown += new System.EventHandler(this.SetUser_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbx_ID;
        private System.Windows.Forms.Label lab_Name;
        private System.Windows.Forms.Label lab_Emp;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_SetUser;
    }
}