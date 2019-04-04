namespace BugTrackingSys_EPAMTest_2
{
    partial class ChangeDelete_Project
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
            this.cmbbxID = new System.Windows.Forms.ComboBox();
            this.Lab_ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rchtxtbxDescr = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbbxID
            // 
            this.cmbbxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxID.FormattingEnabled = true;
            this.cmbbxID.Location = new System.Drawing.Point(40, 12);
            this.cmbbxID.Name = "cmbbxID";
            this.cmbbxID.Size = new System.Drawing.Size(159, 21);
            this.cmbbxID.TabIndex = 26;
            this.cmbbxID.SelectedIndexChanged += new System.EventHandler(this.CmbbxID_SelectedIndexChanged);
            // 
            // Lab_ID
            // 
            this.Lab_ID.AutoSize = true;
            this.Lab_ID.Location = new System.Drawing.Point(93, 15);
            this.Lab_ID.Name = "Lab_ID";
            this.Lab_ID.Size = new System.Drawing.Size(18, 13);
            this.Lab_ID.TabIndex = 25;
            this.Lab_ID.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(359, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "ID:";
            // 
            // rchtxtbxDescr
            // 
            this.rchtxtbxDescr.Location = new System.Drawing.Point(40, 43);
            this.rchtxtbxDescr.Name = "rchtxtbxDescr";
            this.rchtxtbxDescr.Size = new System.Drawing.Size(394, 113);
            this.rchtxtbxDescr.TabIndex = 32;
            this.rchtxtbxDescr.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Название";
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(275, 12);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(159, 20);
            this.txtbxName.TabIndex = 34;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(275, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(35, 13);
            this.labName.TabIndex = 35;
            this.labName.Text = "Name";
            // 
            // ChangeDelete_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 196);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rchtxtbxDescr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbbxID);
            this.Controls.Add(this.Lab_ID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeDelete_Project";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Удалить (изменить) проект";
            this.Shown += new System.EventHandler(this.ChangeDelete_UserProject_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbbxID;
        private System.Windows.Forms.Label Lab_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rchtxtbxDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Label labName;
    }
}