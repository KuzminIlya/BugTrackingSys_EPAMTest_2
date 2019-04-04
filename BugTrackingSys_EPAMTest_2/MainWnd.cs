using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BugTrackingSys_EPAMTest_2
{
    public partial class MainWnd : Form
    {
        public MainWnd()
        {
            InitializeComponent();
        }

        // ОКНА ПРОГРАММЫ
        ChangeDataSource changeDataSource; // окно изменения источника данных
        ChangeDelete_Project changedelete_project; // окно удаления проекта, пользователя
        ChangeDel_User changeDel_User;
        NewTask newTask; // окно добавления (изменения) задач
        NewUser newUser; // окно добавления пользователя
        NewProject newProject; // окно добавления проекта
        DeleteTask delTask; // окно удаления задачи
        public SetDataSource setDataSource { get; set; }
        SetUser setUser;

        // ИСТОЧНИК ДАННЫХ
        public string DataSourcePath { get; set; } // путь
        public string DataSourceFileName { get; set; } // имя файла
        public string DataSourceFullName { get; set; } // полный путь к файлы
        public bool isDataSourceConnect { get; set; } = false; // Флаг, указывающий были загружены данные из файла

        // ПОЛЬЗОВАТЕЛЬ
        public Employee CurrentUser { get; set; }
        public bool isUserLogIn { get; set; } = false; // Флаг, указывающий, вошел ли пользователь

        // СИСТЕМА ОТСЛЕЖИВАНИЯ
        public BTSystem BugTrackingSystem { get; set; }

        // ИЗМЕНЕНИЯ СИСТЕМЫ
        public ISysItem changed_tasks = new Tasks();
        public ISysItem changed_emp = new Employees();
        public ISysItem changed_proj = new Projects();
        // Списки операций, которые были проведены для каждого элемента
        public List<SQCommands> tasks_oper = new List<SQCommands>();
        public List<SQCommands> emp_oper = new List<SQCommands>();
        public List<SQCommands> proj_oper = new List<SQCommands>();
        public bool isSaved { get; set; } = true; // Флаг, указывающий, есть ли несохраненные изменения

        // ДОП. ПОЛЯ И МЕТОДЫ
        public List<uint> ShownKeys { get; set; } // ключи из Tasks, выбранные для отображения (по фильтру)
        public bool isAddedTask { get; set; } = true; // Флаг указывающий на добавление новой или изменение задачи
        public bool isDeleteUserPrj { get; set; } // Флаг, узказывающий на удаление или изм. пользоват. или проекта
        public bool isProj { get; set; } // Флаг, узказывающий на удаление или изм. пользоват. или проекта
        // Показать текущие задачи, пользователей и проекты в таблицах
        void ShowCurrentTasks(List<uint> keys)
        {
            int New = 0, InProcess = 0,
                Resolved = 0, NotResolved = 0,
                InTesting = 0, Tested = 0, Completed = 0, Rejected = 0, i = 0;
            dtgrd_TaskList.Rows.Clear();
            dtgrd_SummaryTaskInfo.Rows.Clear();
            if (keys.Any())
                dtgrd_TaskList.RowCount = keys.Count;
            foreach (uint key in keys)
            {
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.New) New++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.InProcess) InProcess++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.Resolved) Resolved++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.NotResolved) NotResolved++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.InTesting) InTesting++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.Tested) Tested++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.Completed) Completed++;
                if (BugTrackingSystem.tasks[key].Status == TaskStatus.Rejected) Rejected++;
                dtgrd_TaskList[0, i].Value = BugTrackingSystem.tasks[key].ID;
                dtgrd_TaskList[1, i].Value = BugTrackingSystem.tasks[key].Theme;
                dtgrd_TaskList[2, i].Value = BugTrackingSystem.projects[BugTrackingSystem.tasks[key].ProjectID].Name;
                dtgrd_TaskList[3, i].Value = BugTrackingSystem.tasks[key].Type;
                dtgrd_TaskList[4, i].Value = BugTrackingSystem.tasks[key].Priority;
                dtgrd_TaskList[5, i].Value = BugTrackingSystem.employees[BugTrackingSystem.tasks[key].AddedEmployeeID].Name;
                dtgrd_TaskList[6, i].Value = BugTrackingSystem.employees[BugTrackingSystem.tasks[key].ExecutorEmployeeID].Name;
                dtgrd_TaskList[7, i].Value = BugTrackingSystem.tasks[key].Status;
                dtgrd_TaskList[8, i].Value = BugTrackingSystem.tasks[key].Description.ToString();
                i++;
            }
            dtgrd_SummaryTaskInfo[0, 0].Value = i;
            dtgrd_SummaryTaskInfo[1, 0].Value = New;
            dtgrd_SummaryTaskInfo[2, 0].Value = InProcess;
            dtgrd_SummaryTaskInfo[3, 0].Value = Resolved;
            dtgrd_SummaryTaskInfo[4, 0].Value = NotResolved;
            dtgrd_SummaryTaskInfo[5, 0].Value = InTesting;
            dtgrd_SummaryTaskInfo[6, 0].Value = Tested;
            dtgrd_SummaryTaskInfo[7, 0].Value = Completed;
            dtgrd_SummaryTaskInfo[8, 0].Value = Rejected;
        }
        void ShowCurrentUsers()
        {
            int i = 0;
            dtgrd_EmpList.Rows.Clear();
            dtgrd_EmpList.RowCount = BugTrackingSystem.employees.Keys.Count;
            foreach (uint key in BugTrackingSystem.employees.Keys)
            {
                dtgrd_EmpList[0, i].Value = BugTrackingSystem.employees[key].ID;
                dtgrd_EmpList[1, i].Value = BugTrackingSystem.employees[key].Name;
                dtgrd_EmpList[2, i].Value = BugTrackingSystem.employees[key].Position;
                i++;
            }
        }
        void ShowCurrentProjects()
        {
            int i = 0;
            dtgrd_ProjectsList.Rows.Clear();
            dtgrd_ProjectsList.RowCount = BugTrackingSystem.projects.Keys.Count;
            foreach (uint key in BugTrackingSystem.projects.Keys)
            {
                dtgrd_ProjectsList[0, i].Value = BugTrackingSystem.projects[key].ID;
                dtgrd_ProjectsList[1, i].Value = BugTrackingSystem.projects[key].Name;
                dtgrd_ProjectsList[2, i].Value = BugTrackingSystem.projects[key].Description;
                i++;
            }
        }
        // обновить все поля данных в главном окне
        void RefreshView()
        {
            List<string> TaskHead = new List<string>() { "ID", "Тема", "Проект", "Тип", "Приоритет", "Добавил",
                                                                            "Исполнитель", "Статус" };
            // Отображение данных в таблицах на вкладках
            if (isDataSourceConnect && isUserLogIn)
            {
                if (BugTrackingSystem.tasks.Keys.Any())
                {
                    ShowCurrentTasks(BugTrackingSystem.tasks.Keys.ToList());
                    cmbbx_Atr.DataSource = TaskHead;
                    cmbbx_Atr.SelectedIndex = 0;
                    ShownKeys = new List<uint>(BugTrackingSystem.tasks.Keys);
                }
                if(BugTrackingSystem.employees.Keys.Any())
                {
                    ShowCurrentUsers();
                }
                if (BugTrackingSystem.projects.Keys.Any())
                {
                    ShowCurrentProjects();
                }
                cmbbx_ChangedUsPrj.DataSource = new List<string>() { "Пользователи", "Проекты" };
                cmbbx_ChangedUsPrj.SelectedIndex = 0;
            }
        }
        // Сохранить все изменения системы в файл данных
        void SaveAll()
        {
            if (isDataSourceConnect && isUserLogIn)
            {
                SQLite_DataSource.SaveDB(DataSourceFullName, Tables.Empl, emp_oper, changed_emp);
                SQLite_DataSource.SaveDB(DataSourceFullName, Tables.Project, proj_oper, changed_proj);
                SQLite_DataSource.SaveDB(DataSourceFullName, Tables.Task, tasks_oper, changed_tasks);
            }
        }

        // СОБЫТИЯ
        // ВКЛАДКА ЗАДАЧИ
        // Показать задачи, назначенные на текущего пользователя
        private void Btn_MyTask_Click(object sender, EventArgs e)
        {
            // Отображение данных в таблицах на вкладках
            if (isDataSourceConnect && isUserLogIn)
            {
                ShownKeys.Clear();
                foreach(uint key in BugTrackingSystem.tasks.Keys)
                    if(CurrentUser.ID == BugTrackingSystem.tasks[key].ExecutorEmployeeID)
                    {
                        ShownKeys.Add(key);
                    }
                ShowCurrentTasks(ShownKeys);
            }
        }

        // Показать текущий источник данных
        private void Btn_ShowDataSource_Click(object sender, EventArgs e)
        {
            DialogResult dlgres;
            using (changeDataSource = new ChangeDataSource())
            {
                dlgres = changeDataSource.ShowDialog(this);
                if (dlgres == DialogResult.Cancel) return;

                // Закрытие сеанса и сохранение изменений для текущего источника и открытие нового
                this.Text = "";
                isUserLogIn = false;
                SaveAll();
                ISysItem changed_tasks = new Tasks();
                ISysItem changed_emp = new Employees();
                ISysItem changed_proj = new Projects();

                // Открытие или создание нового ист. данных
                if (dlgres == DialogResult.Cancel) return;
                if (dlgres == DialogResult.Yes)
                {
                    SQLite_DataSource.SetData(ref changed_emp, SQLite_DataSource.LoadDB(DataSourceFullName, Tables.Empl));
                    SQLite_DataSource.SetData(ref changed_tasks, SQLite_DataSource.LoadDB(DataSourceFullName, Tables.Task));
                    SQLite_DataSource.SetData(ref changed_proj, SQLite_DataSource.LoadDB(DataSourceFullName, Tables.Project));

                    BugTrackingSystem = new BTSystem(changed_tasks, changed_proj, changed_emp);
                    isDataSourceConnect = true;
                    isSaved = true;
                }
                if (dlgres == DialogResult.OK)
                {
                    SQLite_DataSource.CreateDB(DataSourceFullName);
                    Employee admin = new Employee(0, "Admin", EmpPosition.Head);
                    changed_emp = new Employees(admin);
                    changed_tasks = new Tasks();
                    changed_proj = new Projects();
                    BugTrackingSystem = new BTSystem(changed_tasks, changed_proj, changed_emp);
                    BugTrackingSystem.currentEmployee = admin;
                    CurrentUser = admin;
                    (this.changed_emp as Employees).AddItem(admin);
                    emp_oper.Add(SQCommands.Insert);
                    isSaved = false;

                    this.Text = string.Format("Добро пожаловать, {0}! Ваша должность: {1}. Ваш ID: {2}", admin.Name, admin.Position, admin.ID);

                    isDataSourceConnect = true;
                    isUserLogIn = true;
                    return;
                }

            }

            using (setUser = new SetUser())
            {
                dlgres = setUser.ShowDialog(this);
                if (dlgres == DialogResult.Cancel) return;
                if (!isUserLogIn) isUserLogIn = true;
                BugTrackingSystem.currentEmployee = CurrentUser;
            }

            RefreshView();
        }
        // Показать информацию о текущем пользователе
        private void Btn_ShowUser_Click(object sender, EventArgs e)
        {
            if (isUserLogIn && isDataSourceConnect)
            {
                using (setUser = new SetUser())
                {
                    DialogResult dlgres = setUser.ShowDialog(this);
                    if (dlgres == DialogResult.Cancel) return;
                    BugTrackingSystem.currentEmployee = CurrentUser;
                    if (!isUserLogIn) isUserLogIn = true;
                }
            }
        }
        // Создать новую задачу
        private void Btn_NewTask_Click(object sender, EventArgs e)
        {
            if (isDataSourceConnect && isUserLogIn)
            {
                using (newTask = new NewTask())
                {
                    newTask.Text = "Новая задача";
                    newTask.bx_ID.Visible = false;
                    newTask.Lab_ID.Visible = true;
                    newTask.lab_AddedName.Text = string.Format("{0}: {1}", CurrentUser.ID, CurrentUser.Name);
                    if (CurrentUser.Position == EmpPosition.Head)
                        newTask.lab_Status.Text = TaskStatus.InProcess.ToString();
                    else
                        newTask.lab_Status.Text = TaskStatus.New.ToString();
                    isAddedTask = true;
                    DialogResult dlgres = newTask.ShowDialog(this);
                    if (dlgres == DialogResult.Cancel) return;
                    isSaved = false;
                    RefreshView();
                }
            }
        }
        // Изменить существующую задачу
        private void Btn_ChangeTask_Click(object sender, EventArgs e)
        {
            if (isDataSourceConnect && isUserLogIn)
            {
                using (newTask = new NewTask())
                {
                    newTask.Text = "Изменить задачу";
                    newTask.bx_ID.Visible = true;
                    newTask.Lab_ID.Visible = false;
                    isAddedTask = false;
                    DialogResult dlgres = newTask.ShowDialog(this);
                    if (dlgres == DialogResult.Cancel) return;
                    isSaved = false;
                    RefreshView();
                }
            }
        }
        // Удалить задачу
        private void Btn_DeleteTask_Click(object sender, EventArgs e)
        {
            if (isUserLogIn && isDataSourceConnect)
            {
                using (delTask = new DeleteTask())
                {
                    DialogResult dlgres = delTask.ShowDialog(this);
                    if (dlgres == DialogResult.Cancel) return;
                    RefreshView();
                    isSaved = false;
                }
            }
        }
        // Показать все задачи в системе
        private void Btn_ShawAllTasks_Click(object sender, EventArgs e)
        {
            if (isDataSourceConnect && isUserLogIn)
            {
                ShownKeys = BugTrackingSystem.tasks.Keys.ToList();
                ShowCurrentTasks(ShownKeys);
            }
        }
        // Применить настройки фильтра
        private void Btn_Filt_Click(object sender, EventArgs e)
        {
            if (isDataSourceConnect && isUserLogIn)
            {
                string atrib = cmbbx_Atr.SelectedValue.ToString();
                string val = cmbbx_Val.SelectedValue.ToString();
                bool cond = false;
                List<uint> sel_keys = new List<uint>();

                foreach (uint key in ShownKeys)
                {
                    switch (atrib)
                    {
                        case "ID":
                            cond = BugTrackingSystem.tasks[key].ID.ToString() == val;
                            break;
                        case "Тема":
                            cond = BugTrackingSystem.tasks[key].Theme.ToString() == val;
                            break;
                        case "Проект":
                            cond = BugTrackingSystem.projects[BugTrackingSystem.tasks[key].ProjectID].Name.ToString() == val;
                            break;
                        case "Тип":
                            cond = BugTrackingSystem.tasks[key].Type.ToString() == val;
                            break;
                        case "Приоритет":
                            cond = BugTrackingSystem.tasks[key].Priority.ToString() == val;
                            break;
                        case "Добавил":
                            cond = BugTrackingSystem.employees[BugTrackingSystem.tasks[key].AddedEmployeeID].Name.ToString() == val;
                            break;
                        case "Исполнитель":
                            cond = BugTrackingSystem.employees[BugTrackingSystem.tasks[key].ExecutorEmployeeID].Name.ToString() == val;
                            break;
                        case "Статус":
                            cond = BugTrackingSystem.tasks[key].Status.ToString() == val;
                            break;
                    }

                    if (cond) sel_keys.Add(key);
                }

                ShowCurrentTasks(sel_keys);
            }
        }
        // Выбор данных в выпадающем списке с атрибутами
        private void Cmbbx_Atr_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> source = new List<string>();
            foreach (uint key in BugTrackingSystem.tasks.Keys)
                switch (cmbbx_Atr.SelectedValue)
                {
                    case "ID":
                        source.Add(BugTrackingSystem.tasks[key].ID.ToString());
                        break;
                    case "Тема":
                        source.Add(BugTrackingSystem.tasks[key].Theme.ToString());
                        break;
                    case "Проект":
                        source.Add(BugTrackingSystem.projects[BugTrackingSystem.tasks[key].ProjectID].Name.ToString());
                        break;
                    case "Тип":
                        source.Add(BugTrackingSystem.tasks[key].Type.ToString());
                        break;
                    case "Приоритет":
                        source.Add(BugTrackingSystem.tasks[key].Priority.ToString());
                        break;
                    case "Добавил":
                        source.Add(BugTrackingSystem.employees[BugTrackingSystem.tasks[key].AddedEmployeeID].Name.ToString());
                        break;
                    case "Исполнитель":
                        source.Add(BugTrackingSystem.employees[BugTrackingSystem.tasks[key].ExecutorEmployeeID].Name.ToString());
                        break;
                    case "Статус":
                        source.Add(BugTrackingSystem.tasks[key].Status.ToString());
                        break;
                }
            cmbbx_Val.DataSource = source;
            cmbbx_Val.SelectedIndex = 0;
        }
        // Записать изменения в файл данных
        private void Button1_Click(object sender, EventArgs e)
        {
            if (isDataSourceConnect && isUserLogIn)
            {
                if (!isSaved)
                {
                    SaveAll();
                    changed_tasks = new Tasks();
                    changed_emp = new Employees();
                    changed_proj = new Projects();
                    tasks_oper = new List<SQCommands>();
                    emp_oper = new List<SQCommands>();
                    proj_oper = new List<SQCommands>();
                    isSaved = true;
                }
            }
        }

        // ВКЛАДКА ПРОЕКТЫ И ПОЛЬЗОВАТЕЛИ
        // Добавить проект
        private void Btn_NewProject_Click(object sender, EventArgs e)
        {
            if (isUserLogIn && isDataSourceConnect)
            {
                using (newProject = new NewProject())
                {
                    DialogResult dlgres = newProject.ShowDialog(this);
                    if (dlgres == DialogResult.Cancel) return;
                    RefreshView();
                    isSaved = false;
                }
            }
        }
        // Добавить пользователя
        private void Btn_NewUser_Click(object sender, EventArgs e)
        {
            if (isUserLogIn && isDataSourceConnect)
            {
                using (newUser = new NewUser())
                {
                    DialogResult dlgres = newUser.ShowDialog(this);
                    if (dlgres == DialogResult.Cancel) return;
                    RefreshView();
                    isSaved = false;
                }
            }
        }
        // Изменить проект или пользователя
        private void Btn_Change_Click(object sender, EventArgs e)
        {
            if (isUserLogIn && isDataSourceConnect)
            {
                using (changedelete_project = new ChangeDelete_Project())
                {
                    isDeleteUserPrj = false;
                    DialogResult dlgres;
                    if (cmbbx_ChangedUsPrj.SelectedValue.ToString() == "Проекты")
                        using (changedelete_project = new ChangeDelete_Project())
                        {
                            dlgres = changedelete_project.ShowDialog(this);
                        }
                    else
                        using (changeDel_User = new ChangeDel_User())
                        {
                            dlgres = changeDel_User.ShowDialog(this);
                        }
                    if (dlgres == DialogResult.Cancel) return;
                    RefreshView();
                    isSaved = false;
                }
            }
        }
        // Удалить проект или пользователя
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (isUserLogIn && isDataSourceConnect)
            {
                using (changedelete_project = new ChangeDelete_Project())
                {
                    isDeleteUserPrj = true;
                    DialogResult dlgres;
                    if (cmbbx_ChangedUsPrj.SelectedValue.ToString() == "Проекты")
                        using (changedelete_project = new ChangeDelete_Project())
                        {
                            dlgres = changedelete_project.ShowDialog(this);
                        }
                    else
                        using (changeDel_User = new ChangeDel_User())
                        {
                            dlgres = changeDel_User.ShowDialog(this);
                        }
                    if (dlgres == DialogResult.Cancel) return;
                    RefreshView();
                    isSaved = false;
                }
            }
        }


        // СОБЫТИЯ ГЛАВНОГО ОКНА
        // Выбор источника данных и пользователя перед отображением окна
        private void MainWnd_Shown(object sender, EventArgs e)
        {
            // создание нового источника данных или подключение к выбранному
            DialogResult dlgres;
            ISysItem changed_tasks = new Tasks();
            ISysItem changed_emp = new Employees();
            ISysItem changed_proj = new Projects();
            using (setDataSource = new SetDataSource())
            {
                dlgres = setDataSource.ShowDialog(this);
                if (dlgres == DialogResult.Cancel) return;
                if (dlgres == DialogResult.Yes)
                {
                    SQLite_DataSource.SetData(ref changed_emp, SQLite_DataSource.LoadDB(DataSourceFullName, Tables.Empl));
                    SQLite_DataSource.SetData(ref changed_tasks, SQLite_DataSource.LoadDB(DataSourceFullName, Tables.Task));
                    SQLite_DataSource.SetData(ref changed_proj, SQLite_DataSource.LoadDB(DataSourceFullName, Tables.Project));

                    BugTrackingSystem = new BTSystem(changed_tasks, changed_proj, changed_emp);
                    isDataSourceConnect = true;
                }
                if (dlgres == DialogResult.OK)
                {
                    SQLite_DataSource.CreateDB(DataSourceFullName);
                    Employee admin = new Employee(0, "Admin", EmpPosition.Head);
                    changed_emp = new Employees(admin);
                    changed_tasks = new Tasks();
                    changed_proj = new Projects();
                    BugTrackingSystem = new BTSystem(changed_tasks, changed_proj, changed_emp);
                    BugTrackingSystem.currentEmployee = admin;
                    CurrentUser = admin;
                    (this.changed_emp as Employees).AddItem(admin);
                    emp_oper.Add(SQCommands.Insert);

                    this.Text = string.Format("Добро пожаловать, {0}! Ваша должность: {1}. Ваш ID: {2}", admin.Name, admin.Position, admin.ID);

                    isDataSourceConnect = true;
                    isUserLogIn = true;
                    return;
                }
            }
            using (setUser = new SetUser())
            {
                dlgres = setUser.ShowDialog(this);
                if (dlgres == DialogResult.Cancel) return;
                isUserLogIn = true;
                BugTrackingSystem.currentEmployee = CurrentUser;
            }

            RefreshView();

        }

        // Обновление источника данных перед закрытием окна
        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAll();
        }
    }
}
