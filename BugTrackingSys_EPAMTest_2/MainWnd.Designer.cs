namespace BugTrackingSys_EPAMTest_2
{
    partial class MainWnd
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPg_Projects = new System.Windows.Forms.TabPage();
            this.btn_NewProject = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgrd_ProjectsList = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgrd_EmpList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbbx_ChangedUsPrj = new System.Windows.Forms.ComboBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_NewUser = new System.Windows.Forms.Button();
            this.btn_Change = new System.Windows.Forms.Button();
            this.tbPg_Tasks = new System.Windows.Forms.TabPage();
            this.btn_ShawAllTasks = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_MyTask = new System.Windows.Forms.Button();
            this.btn_ShowDataSource = new System.Windows.Forms.Button();
            this.btn_ShowUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Filt = new System.Windows.Forms.Button();
            this.cmbbx_Val = new System.Windows.Forms.ComboBox();
            this.cmbbx_Atr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBx_ComInfo = new System.Windows.Forms.GroupBox();
            this.dtgrd_SummaryTaskInfo = new System.Windows.Forms.DataGridView();
            this.ComInf_NumTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComInf_New = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComInf_InProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComInf_Decided = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComInf_OnTesting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComInf_Completed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBx_TaskList = new System.Windows.Forms.GroupBox();
            this.btn_DeleteTask = new System.Windows.Forms.Button();
            this.btn_ChangeTask = new System.Windows.Forms.Button();
            this.btn_NewTask = new System.Windows.Forms.Button();
            this.dtgrd_TaskList = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Creater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Descript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPg_Projects.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_ProjectsList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_EmpList)).BeginInit();
            this.tbPg_Tasks.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpBx_ComInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_SummaryTaskInfo)).BeginInit();
            this.grpBx_TaskList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_TaskList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPg_Projects
            // 
            this.tbPg_Projects.Controls.Add(this.btn_NewProject);
            this.tbPg_Projects.Controls.Add(this.groupBox3);
            this.tbPg_Projects.Controls.Add(this.groupBox2);
            this.tbPg_Projects.Controls.Add(this.cmbbx_ChangedUsPrj);
            this.tbPg_Projects.Controls.Add(this.btn_Delete);
            this.tbPg_Projects.Controls.Add(this.btn_NewUser);
            this.tbPg_Projects.Controls.Add(this.btn_Change);
            this.tbPg_Projects.Location = new System.Drawing.Point(4, 24);
            this.tbPg_Projects.Margin = new System.Windows.Forms.Padding(4);
            this.tbPg_Projects.Name = "tbPg_Projects";
            this.tbPg_Projects.Size = new System.Drawing.Size(1252, 494);
            this.tbPg_Projects.TabIndex = 2;
            this.tbPg_Projects.Text = "Проекты и пользователи";
            this.tbPg_Projects.UseVisualStyleBackColor = true;
            // 
            // btn_NewProject
            // 
            this.btn_NewProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_NewProject.Location = new System.Drawing.Point(202, 449);
            this.btn_NewProject.Name = "btn_NewProject";
            this.btn_NewProject.Size = new System.Drawing.Size(174, 26);
            this.btn_NewProject.TabIndex = 22;
            this.btn_NewProject.Text = "Новый проект...";
            this.btn_NewProject.UseVisualStyleBackColor = true;
            this.btn_NewProject.Click += new System.EventHandler(this.Btn_NewProject_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgrd_ProjectsList);
            this.groupBox3.Location = new System.Drawing.Point(667, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 428);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Проекты";
            // 
            // dtgrd_ProjectsList
            // 
            this.dtgrd_ProjectsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrd_ProjectsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.dtgrd_ProjectsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrd_ProjectsList.Location = new System.Drawing.Point(3, 17);
            this.dtgrd_ProjectsList.Name = "dtgrd_ProjectsList";
            this.dtgrd_ProjectsList.ReadOnly = true;
            this.dtgrd_ProjectsList.Size = new System.Drawing.Size(571, 408);
            this.dtgrd_ProjectsList.TabIndex = 20;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Название";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgrd_EmpList);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 431);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пользователи";
            // 
            // dtgrd_EmpList
            // 
            this.dtgrd_EmpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrd_EmpList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5});
            this.dtgrd_EmpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrd_EmpList.Location = new System.Drawing.Point(3, 17);
            this.dtgrd_EmpList.Name = "dtgrd_EmpList";
            this.dtgrd_EmpList.ReadOnly = true;
            this.dtgrd_EmpList.Size = new System.Drawing.Size(652, 411);
            this.dtgrd_EmpList.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 180;
            // 
            // cmbbx_ChangedUsPrj
            // 
            this.cmbbx_ChangedUsPrj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_ChangedUsPrj.FormattingEnabled = true;
            this.cmbbx_ChangedUsPrj.Items.AddRange(new object[] {
            "Пользователи",
            "Проекты"});
            this.cmbbx_ChangedUsPrj.Location = new System.Drawing.Point(771, 451);
            this.cmbbx_ChangedUsPrj.Name = "cmbbx_ChangedUsPrj";
            this.cmbbx_ChangedUsPrj.Size = new System.Drawing.Size(230, 23);
            this.cmbbx_ChangedUsPrj.TabIndex = 18;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Delete.Location = new System.Drawing.Point(1129, 451);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(112, 23);
            this.btn_Delete.TabIndex = 17;
            this.btn_Delete.Text = "Удалить...";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // btn_NewUser
            // 
            this.btn_NewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_NewUser.Location = new System.Drawing.Point(6, 449);
            this.btn_NewUser.Name = "btn_NewUser";
            this.btn_NewUser.Size = new System.Drawing.Size(190, 26);
            this.btn_NewUser.TabIndex = 15;
            this.btn_NewUser.Text = "Новый пользователь...";
            this.btn_NewUser.UseVisualStyleBackColor = true;
            this.btn_NewUser.Click += new System.EventHandler(this.Btn_NewUser_Click);
            // 
            // btn_Change
            // 
            this.btn_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Change.Location = new System.Drawing.Point(1008, 451);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(112, 23);
            this.btn_Change.TabIndex = 16;
            this.btn_Change.Text = "Изменить...";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.Btn_Change_Click);
            // 
            // tbPg_Tasks
            // 
            this.tbPg_Tasks.Controls.Add(this.btn_ShawAllTasks);
            this.tbPg_Tasks.Controls.Add(this.button1);
            this.tbPg_Tasks.Controls.Add(this.btn_MyTask);
            this.tbPg_Tasks.Controls.Add(this.btn_ShowDataSource);
            this.tbPg_Tasks.Controls.Add(this.btn_ShowUser);
            this.tbPg_Tasks.Controls.Add(this.groupBox1);
            this.tbPg_Tasks.Controls.Add(this.grpBx_ComInfo);
            this.tbPg_Tasks.Controls.Add(this.grpBx_TaskList);
            this.tbPg_Tasks.Location = new System.Drawing.Point(4, 24);
            this.tbPg_Tasks.Margin = new System.Windows.Forms.Padding(4);
            this.tbPg_Tasks.Name = "tbPg_Tasks";
            this.tbPg_Tasks.Padding = new System.Windows.Forms.Padding(4);
            this.tbPg_Tasks.Size = new System.Drawing.Size(1252, 494);
            this.tbPg_Tasks.TabIndex = 0;
            this.tbPg_Tasks.Text = "Задачи";
            this.tbPg_Tasks.UseVisualStyleBackColor = true;
            // 
            // btn_ShawAllTasks
            // 
            this.btn_ShawAllTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ShawAllTasks.Location = new System.Drawing.Point(130, 7);
            this.btn_ShawAllTasks.Name = "btn_ShawAllTasks";
            this.btn_ShawAllTasks.Size = new System.Drawing.Size(126, 28);
            this.btn_ShawAllTasks.TabIndex = 16;
            this.btn_ShawAllTasks.Text = "Все задачи";
            this.btn_ShawAllTasks.UseVisualStyleBackColor = true;
            this.btn_ShawAllTasks.Click += new System.EventHandler(this.Btn_ShawAllTasks_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(575, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_MyTask
            // 
            this.btn_MyTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_MyTask.Location = new System.Drawing.Point(13, 7);
            this.btn_MyTask.Name = "btn_MyTask";
            this.btn_MyTask.Size = new System.Drawing.Size(111, 28);
            this.btn_MyTask.TabIndex = 17;
            this.btn_MyTask.Text = "Мои задачи";
            this.btn_MyTask.UseVisualStyleBackColor = true;
            this.btn_MyTask.Click += new System.EventHandler(this.Btn_MyTask_Click);
            // 
            // btn_ShowDataSource
            // 
            this.btn_ShowDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ShowDataSource.Location = new System.Drawing.Point(692, 7);
            this.btn_ShowDataSource.Name = "btn_ShowDataSource";
            this.btn_ShowDataSource.Size = new System.Drawing.Size(140, 28);
            this.btn_ShowDataSource.TabIndex = 15;
            this.btn_ShowDataSource.Text = "Источник данных...";
            this.btn_ShowDataSource.UseVisualStyleBackColor = true;
            this.btn_ShowDataSource.Click += new System.EventHandler(this.Btn_ShowDataSource_Click);
            // 
            // btn_ShowUser
            // 
            this.btn_ShowUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ShowUser.Location = new System.Drawing.Point(838, 7);
            this.btn_ShowUser.Name = "btn_ShowUser";
            this.btn_ShowUser.Size = new System.Drawing.Size(126, 28);
            this.btn_ShowUser.TabIndex = 14;
            this.btn_ShowUser.Text = "Пользователь...";
            this.btn_ShowUser.UseVisualStyleBackColor = true;
            this.btn_ShowUser.Click += new System.EventHandler(this.Btn_ShowUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Filt);
            this.groupBox1.Controls.Add(this.cmbbx_Val);
            this.groupBox1.Controls.Add(this.cmbbx_Atr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(970, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // btn_Filt
            // 
            this.btn_Filt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Filt.Location = new System.Drawing.Point(140, 108);
            this.btn_Filt.Name = "btn_Filt";
            this.btn_Filt.Size = new System.Drawing.Size(126, 28);
            this.btn_Filt.TabIndex = 15;
            this.btn_Filt.Text = "Применить";
            this.btn_Filt.UseVisualStyleBackColor = true;
            this.btn_Filt.Click += new System.EventHandler(this.Btn_Filt_Click);
            // 
            // cmbbx_Val
            // 
            this.cmbbx_Val.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Val.FormattingEnabled = true;
            this.cmbbx_Val.Location = new System.Drawing.Point(94, 65);
            this.cmbbx_Val.Name = "cmbbx_Val";
            this.cmbbx_Val.Size = new System.Drawing.Size(172, 23);
            this.cmbbx_Val.TabIndex = 3;
            // 
            // cmbbx_Atr
            // 
            this.cmbbx_Atr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Atr.FormattingEnabled = true;
            this.cmbbx_Atr.Location = new System.Drawing.Point(94, 24);
            this.cmbbx_Atr.Name = "cmbbx_Atr";
            this.cmbbx_Atr.Size = new System.Drawing.Size(172, 23);
            this.cmbbx_Atr.TabIndex = 2;
            this.cmbbx_Atr.SelectedIndexChanged += new System.EventHandler(this.Cmbbx_Atr_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Значение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Атрибут";
            // 
            // grpBx_ComInfo
            // 
            this.grpBx_ComInfo.Controls.Add(this.dtgrd_SummaryTaskInfo);
            this.grpBx_ComInfo.Location = new System.Drawing.Point(12, 42);
            this.grpBx_ComInfo.Margin = new System.Windows.Forms.Padding(4);
            this.grpBx_ComInfo.Name = "grpBx_ComInfo";
            this.grpBx_ComInfo.Padding = new System.Windows.Forms.Padding(4);
            this.grpBx_ComInfo.Size = new System.Drawing.Size(956, 107);
            this.grpBx_ComInfo.TabIndex = 3;
            this.grpBx_ComInfo.TabStop = false;
            this.grpBx_ComInfo.Text = "Общая информация";
            // 
            // dtgrd_SummaryTaskInfo
            // 
            this.dtgrd_SummaryTaskInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrd_SummaryTaskInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComInf_NumTask,
            this.ComInf_New,
            this.ComInf_InProcess,
            this.ComInf_Decided,
            this.Column1,
            this.ComInf_OnTesting,
            this.Column2,
            this.ComInf_Completed,
            this.Column3});
            this.dtgrd_SummaryTaskInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrd_SummaryTaskInfo.Location = new System.Drawing.Point(4, 18);
            this.dtgrd_SummaryTaskInfo.Name = "dtgrd_SummaryTaskInfo";
            this.dtgrd_SummaryTaskInfo.ReadOnly = true;
            this.dtgrd_SummaryTaskInfo.Size = new System.Drawing.Size(948, 85);
            this.dtgrd_SummaryTaskInfo.TabIndex = 1;
            // 
            // ComInf_NumTask
            // 
            this.ComInf_NumTask.HeaderText = "Задач";
            this.ComInf_NumTask.Name = "ComInf_NumTask";
            this.ComInf_NumTask.ReadOnly = true;
            // 
            // ComInf_New
            // 
            this.ComInf_New.HeaderText = "Новых";
            this.ComInf_New.Name = "ComInf_New";
            this.ComInf_New.ReadOnly = true;
            // 
            // ComInf_InProcess
            // 
            this.ComInf_InProcess.HeaderText = "В работе";
            this.ComInf_InProcess.Name = "ComInf_InProcess";
            this.ComInf_InProcess.ReadOnly = true;
            // 
            // ComInf_Decided
            // 
            this.ComInf_Decided.HeaderText = "Решенных";
            this.ComInf_Decided.Name = "ComInf_Decided";
            this.ComInf_Decided.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Не решенных";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ComInf_OnTesting
            // 
            this.ComInf_OnTesting.HeaderText = "На тестировании";
            this.ComInf_OnTesting.Name = "ComInf_OnTesting";
            this.ComInf_OnTesting.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Протестированных";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ComInf_Completed
            // 
            this.ComInf_Completed.HeaderText = "Завершенных";
            this.ComInf_Completed.Name = "ComInf_Completed";
            this.ComInf_Completed.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Отклоненных";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // grpBx_TaskList
            // 
            this.grpBx_TaskList.Controls.Add(this.btn_DeleteTask);
            this.grpBx_TaskList.Controls.Add(this.btn_ChangeTask);
            this.grpBx_TaskList.Controls.Add(this.btn_NewTask);
            this.grpBx_TaskList.Controls.Add(this.dtgrd_TaskList);
            this.grpBx_TaskList.Location = new System.Drawing.Point(12, 152);
            this.grpBx_TaskList.Margin = new System.Windows.Forms.Padding(4);
            this.grpBx_TaskList.Name = "grpBx_TaskList";
            this.grpBx_TaskList.Padding = new System.Windows.Forms.Padding(4);
            this.grpBx_TaskList.Size = new System.Drawing.Size(1230, 354);
            this.grpBx_TaskList.TabIndex = 0;
            this.grpBx_TaskList.TabStop = false;
            this.grpBx_TaskList.Text = "Список задач";
            // 
            // btn_DeleteTask
            // 
            this.btn_DeleteTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DeleteTask.Location = new System.Drawing.Point(290, 308);
            this.btn_DeleteTask.Name = "btn_DeleteTask";
            this.btn_DeleteTask.Size = new System.Drawing.Size(112, 23);
            this.btn_DeleteTask.TabIndex = 13;
            this.btn_DeleteTask.Text = "Удалить...";
            this.btn_DeleteTask.UseVisualStyleBackColor = true;
            this.btn_DeleteTask.Click += new System.EventHandler(this.Btn_DeleteTask_Click);
            // 
            // btn_ChangeTask
            // 
            this.btn_ChangeTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ChangeTask.Location = new System.Drawing.Point(143, 308);
            this.btn_ChangeTask.Name = "btn_ChangeTask";
            this.btn_ChangeTask.Size = new System.Drawing.Size(141, 23);
            this.btn_ChangeTask.TabIndex = 12;
            this.btn_ChangeTask.Text = "Изменить...";
            this.btn_ChangeTask.UseVisualStyleBackColor = true;
            this.btn_ChangeTask.Click += new System.EventHandler(this.Btn_ChangeTask_Click);
            // 
            // btn_NewTask
            // 
            this.btn_NewTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_NewTask.Location = new System.Drawing.Point(9, 308);
            this.btn_NewTask.Name = "btn_NewTask";
            this.btn_NewTask.Size = new System.Drawing.Size(128, 23);
            this.btn_NewTask.TabIndex = 11;
            this.btn_NewTask.Text = "Новая задача...";
            this.btn_NewTask.UseVisualStyleBackColor = true;
            this.btn_NewTask.Click += new System.EventHandler(this.Btn_NewTask_Click);
            // 
            // dtgrd_TaskList
            // 
            this.dtgrd_TaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrd_TaskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Task_Note,
            this.Task_Project,
            this.Task_Type,
            this.Task_Priority,
            this.Task_Creater,
            this.Task_Executor,
            this.Task_State,
            this.Task_Descript});
            this.dtgrd_TaskList.Location = new System.Drawing.Point(9, 21);
            this.dtgrd_TaskList.Name = "dtgrd_TaskList";
            this.dtgrd_TaskList.ReadOnly = true;
            this.dtgrd_TaskList.Size = new System.Drawing.Size(1214, 281);
            this.dtgrd_TaskList.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Task_Note
            // 
            this.Task_Note.HeaderText = "Тема";
            this.Task_Note.Name = "Task_Note";
            this.Task_Note.ReadOnly = true;
            this.Task_Note.Width = 280;
            // 
            // Task_Project
            // 
            this.Task_Project.HeaderText = "Проект";
            this.Task_Project.Name = "Task_Project";
            this.Task_Project.ReadOnly = true;
            this.Task_Project.Width = 200;
            // 
            // Task_Type
            // 
            this.Task_Type.HeaderText = "Тип";
            this.Task_Type.Name = "Task_Type";
            this.Task_Type.ReadOnly = true;
            // 
            // Task_Priority
            // 
            this.Task_Priority.HeaderText = "Приоритет";
            this.Task_Priority.Name = "Task_Priority";
            this.Task_Priority.ReadOnly = true;
            // 
            // Task_Creater
            // 
            this.Task_Creater.HeaderText = "Добавил";
            this.Task_Creater.Name = "Task_Creater";
            this.Task_Creater.ReadOnly = true;
            // 
            // Task_Executor
            // 
            this.Task_Executor.HeaderText = "Исполнитель";
            this.Task_Executor.Name = "Task_Executor";
            this.Task_Executor.ReadOnly = true;
            // 
            // Task_State
            // 
            this.Task_State.HeaderText = "Состояние";
            this.Task_State.Name = "Task_State";
            this.Task_State.ReadOnly = true;
            // 
            // Task_Descript
            // 
            this.Task_Descript.HeaderText = "Описание";
            this.Task_Descript.Name = "Task_Descript";
            this.Task_Descript.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPg_Tasks);
            this.tabControl1.Controls.Add(this.tbPg_Projects);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1260, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 522);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWnd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWnd_FormClosing);
            this.Shown += new System.EventHandler(this.MainWnd_Shown);
            this.tbPg_Projects.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_ProjectsList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_EmpList)).EndInit();
            this.tbPg_Tasks.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBx_ComInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_SummaryTaskInfo)).EndInit();
            this.grpBx_TaskList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd_TaskList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tbPg_Projects;
        private System.Windows.Forms.TabPage tbPg_Tasks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbbx_Val;
        private System.Windows.Forms.ComboBox cmbbx_Atr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBx_TaskList;
        private System.Windows.Forms.DataGridView dtgrd_TaskList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_NewTask;
        private System.Windows.Forms.Button btn_DeleteTask;
        private System.Windows.Forms.Button btn_ChangeTask;
        private System.Windows.Forms.ComboBox cmbbx_ChangedUsPrj;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_NewUser;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgrd_ProjectsList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgrd_EmpList;
        private System.Windows.Forms.Button btn_ShowUser;
        private System.Windows.Forms.Button btn_NewProject;
        private System.Windows.Forms.Button btn_ShowDataSource;
        private System.Windows.Forms.Button btn_MyTask;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Filt;
        private System.Windows.Forms.Button btn_ShawAllTasks;
        private System.Windows.Forms.GroupBox grpBx_ComInfo;
        private System.Windows.Forms.DataGridView dtgrd_SummaryTaskInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComInf_NumTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComInf_New;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComInf_InProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComInf_Decided;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComInf_OnTesting;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComInf_Completed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Creater;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Executor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Descript;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}

