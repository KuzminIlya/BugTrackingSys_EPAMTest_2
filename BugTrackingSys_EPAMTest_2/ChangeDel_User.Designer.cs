namespace BugTrackingSys_EPAMTest_2
{
    partial class ChangeDel_User
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
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbxPos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbbxID = new System.Windows.Forms.ComboBox();
            this.Lab_ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labPos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(96, 39);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(159, 20);
            this.txtbxName.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Имя:";
            // 
            // cmbbxPos
            // 
            this.cmbbxPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxPos.FormattingEnabled = true;
            this.cmbbxPos.Location = new System.Drawing.Point(96, 69);
            this.cmbbxPos.Name = "cmbbxPos";
            this.cmbbxPos.Size = new System.Drawing.Size(159, 21);
            this.cmbbxPos.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Должность:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(99, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(180, 109);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // cmbbxID
            // 
            this.cmbbxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxID.FormattingEnabled = true;
            this.cmbbxID.Location = new System.Drawing.Point(96, 12);
            this.cmbbxID.Name = "cmbbxID";
            this.cmbbxID.Size = new System.Drawing.Size(159, 21);
            this.cmbbxID.TabIndex = 37;
            this.cmbbxID.SelectedIndexChanged += new System.EventHandler(this.CmbbxID_SelectedIndexChanged);
            // 
            // Lab_ID
            // 
            this.Lab_ID.AutoSize = true;
            this.Lab_ID.Location = new System.Drawing.Point(113, 15);
            this.Lab_ID.Name = "Lab_ID";
            this.Lab_ID.Size = new System.Drawing.Size(18, 13);
            this.Lab_ID.TabIndex = 36;
            this.Lab_ID.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "ID:";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(96, 42);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(33, 13);
            this.labName.TabIndex = 46;
            this.labName.Text = "name";
            // 
            // labPos
            // 
            this.labPos.AutoSize = true;
            this.labPos.Location = new System.Drawing.Point(96, 72);
            this.labPos.Name = "labPos";
            this.labPos.Size = new System.Drawing.Size(25, 13);
            this.labPos.TabIndex = 47;
            this.labPos.Text = "Pos";
            // 
            // ChangeDel_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 149);
            this.Controls.Add(this.labPos);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbbxPos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbbxID);
            this.Controls.Add(this.Lab_ID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeDel_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Удалить (изменить) пользователя";
            this.Shown += new System.EventHandler(this.ChangeDel_User_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbxPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbbxID;
        private System.Windows.Forms.Label Lab_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labPos;
    }
}