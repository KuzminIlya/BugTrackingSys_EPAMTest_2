using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace BugTrackingSys_EPAMTest_2
{
    public enum SQCommands { Insert, Update, Delete }; // Допустимые команды
    public enum Tables { Task, Empl, Project }; // Виды элементов системы

    // Статический класс, содержащий методы чтения, записи и обновления файла источника данных
    // системы, в случае SQLite
    public static class SQLite_DataSource
    {
        // данные таблиц
        public static readonly List<string> Tabs = new List<string>() { "Пользователи", "Проекты", "Задачи" };

        // Cоздание нового файла БД
        public static void CreateDB(string FileName)
        {
            SQLiteConnection db_Connection = new SQLiteConnection();
            SQLiteCommand db_Command = new SQLiteCommand();
            SQLiteConnection.CreateFile(FileName); // Создание файла БД

            using (db_Connection = new SQLiteConnection(string.Format("Data Source = {0}; Version=3;", FileName)))
            {
                db_Connection.Open();
                db_Command.Connection = db_Connection;

                // Создание таблиц в базе
                db_Command.CommandText = "CREATE TABLE Пользователи" +
                                        "(" +
                                            "ID                     TEXT        NOT NULL    UNIQUE, " +
                                            "Имя                    TEXT        NOT NULL, " +
                                            "Должность              TEXT        NOT NULL," +

                                            "PRIMARY KEY (ID)" +
                                         ");";

                db_Command.CommandText += " CREATE TABLE Проекты" +
                                         "(" +
                                            "ID                      TEXT    NOT NULL    UNIQUE, " +
                                            "Название                TEXT    NOT NULL, " +
                                            "Описание                TEXT," +

                                            "PRIMARY KEY (ID)" +
                                          ");";

                db_Command.CommandText += " CREATE TABLE Задачи" +
                                          "(" +
                                            "ID                 TEXT        NOT NULL," +
                                            "Тема               TEXT        NOT NULL," +
                                            "Проект             TEXT        NOT NULL," +
                                            "Тип                TEXT        NOT NULL," +
                                            "Приоритет          TEXT        NOT NULL," +
                                            "Добавил            TEXT        NOT NULL," +
                                            "Исполнитель        TEXT        NOT NULL," +
                                            "Статус             TEXT        NOT NULL," +
                                            "Описание           TEXT," +

                                            "PRIMARY KEY (ID)," +
                                            "FOREIGN KEY (Добавил)      REFERENCES Пользователи(ID)," +
                                            "FOREIGN KEY (Исполнитель)  REFERENCES Пользователи(ID)," +
                                            "FOREIGN KEY (Проект)       REFERENCES Проекты(ID)" +
                                           ");";

                db_Command.ExecuteNonQuery();
            }
        }

        // Загрузка данных из файла БД
        public static string[,] LoadDB(string FileName, Tables Table_Name)
        {
            string[,] Arr;
            SQLiteConnection DB;
            string Table = "";
            switch (Table_Name)
            {
                case Tables.Task: Table = Tabs[2]; break;
                case Tables.Empl: Table = Tabs[0]; break;
                case Tables.Project: Table = Tabs[1]; break;
            }
            using (DB = new SQLiteConnection("Data Source = " + FileName + "; Version=3;"))
            {
                DB.Open();
                DataTable DB_Table = new DataTable();
                SQLiteDataAdapter DB_Adapter = new SQLiteDataAdapter("SELECT * FROM " + Table, DB);
                DB_Adapter.Fill(DB_Table);
                if (DB_Table.Rows.Count == 0) return null;
                int NumAttr = DB_Table.Rows[0].ItemArray.Count();
                Arr = new string[NumAttr, DB_Table.Rows.Count];
                for (int i = 0; i < DB_Table.Rows.Count; i++)
                {
                    for (int j = 0; j < NumAttr; j++)
                    {
                        Arr[j, i] = DB_Table.Rows[i].ItemArray[j].ToString();
                    }
                }
            }
            return Arr;
        }

        // Сохранение данных в файл БД
        public static void SaveDB(string FileName, Tables tab, List<SQCommands> sqCommand, ISysItem items)
        {
            if (sqCommand.Count == 0) return;
            SQLiteConnection DB;
            SQLiteCommand DB_Command = new SQLiteCommand();
            List<string> TaskHead = new List<string>() { "ID", "Тема", "Проект", "Тип", "Приоритет", "Добавил",
                                                                            "Исполнитель", "Статус", "Описание" };
            List<string> EmpHead = new List<string>() { "ID", "Имя", "Должность" };
            List<string> PrjHead = new List<string>() { "ID", "Название", "Описание" };

        List<string> Head = new List<string>();
            string Table = "";
            switch(tab)
            {
                case Tables.Task: Head = TaskHead; Table = Tabs[2]; break;
                case Tables.Empl: Head = EmpHead; Table = Tabs[0]; break;
                case Tables.Project: Head = PrjHead; Table = Tabs[1]; break;
            }
            using (DB = new SQLiteConnection("Data Source = " + FileName + "; Version=3;"))
            {
                DB.Open();
                DB_Command.Connection = DB;
                DB_Command.CommandText += GetInsertStr(Table, Head, GetData(items, SQCommands.Insert, sqCommand));
                DB_Command.CommandText += GetDeleteStr(Table, Head[0], GetPrimaryKeys(items, SQCommands.Delete, sqCommand));
                DB_Command.CommandText += GetUpdateStr(Table, Head, GetData(items, SQCommands.Update, sqCommand));
                DB_Command.ExecuteNonQuery();
            }
        }

        // Запрос на вставку в БД
        public static string GetInsertStr(string TableName, List<string> Head, string[,] Arr)
        {
            string Fields = "(";
            for (int i = 0; i < Head.Count - 1; i++)
            {
                Fields += Head[i] + ", ";
            }
            Fields += Head[Head.Count - 1] + ")";

            // формирование ряда запросов INSERT в соответствии с заданным количеством добавляемых элементов
            string Command = "";
            for (int i = 0; i < Arr.GetLength(1); i++)
            {
                Command += "INSERT INTO " + TableName + " " + Fields + " VALUES (";
                for (int j = 0; j < Arr.GetLength(0) - 1; j++)
                {
                    Command += "\'" + Arr[j, i] + "\', ";
                }
                Command += "\'" + Arr[Arr.GetLength(0) - 1, i] + "\');";
            }

            return Command;
        }

        // Запрос на удаление из БД
        public static string GetDeleteStr(string TabName, string Head, string[] PK)
        {
            // Прохождение по введенным первичным ключам и формирование запроса на удаление для каждого из них
            string Command = "";
            for (int i = 0; i < PK.Length; i++)
            {
                Command += "DELETE FROM " + TabName + " WHERE " + Head + " = ";
                Command += "\'" + PK[i] + "\';";
            }
            return Command;
        }

        // Запрос на изменение в БД
        public static string GetUpdateStr(string TableName, List<string> Head, string[,] Arr)
        {
            // формирование ряда запросов UPDATE 
            string Command = "";
            for (int i = 0; i < Arr.GetLength(1); i++)
            {
                Command += "UPDATE " + TableName + " SET ";
                for (int j = 0; j < Arr.GetLength(0) - 1; j++)
                {
                    Command += string.Format("{0} = \'{1}\', ", Head[j], Arr[j, i]);
                }
                Command += string.Format("{0} = \'{1}\'", Head[Arr.GetLength(0) - 1], Arr[Arr.GetLength(0) - 1, i]);
                Command += string.Format(" WHERE {0} = \'{1}\';", Head[0], Arr[0, i]);
            }

            return Command;
        }

        // Запись элементов системы в массивы для использования в методах сохранения и загр. из БД
        public static string[,] GetData(ISysItem sysItem, SQCommands cmd, List<SQCommands> cmdlist)
        {
            string[,] arr = null;

            if(sysItem is Tasks)
            {
                Tasks t = sysItem as Tasks;

                int num_atr = 9, num_cort = 0;
                List<uint> sel_keys = new List<uint>();
                int i = 0;
                foreach(uint k in t.Keys)
                {
                    if (cmdlist[i] == cmd)
                    {
                        num_cort++;
                        sel_keys.Add(k);
                    }
                    i++;
                }

                arr = new string[num_atr, num_cort];
                i = 0;
                foreach (uint k in sel_keys)
                {
                    arr[0, i] = t[k].ID.ToString(); arr[1, i] = t[k].Theme.ToString();
                    arr[2, i] = t[k].ProjectID.ToString(); arr[3, i] = t[k].Type.ToString();
                    arr[4, i] = t[k].Priority.ToString(); arr[5, i] = t[k].AddedEmployeeID.ToString();
                    arr[6, i] = t[k].ExecutorEmployeeID.ToString(); arr[7, i] = t[k].Status.ToString();
                    arr[8, i] = t[k].Description.ToString();
                    i++;
                }
            }
            if (sysItem is Employees)
            {
                Employees t = sysItem as Employees;
                int num_atr = 3, num_cort = 0;

                List<uint> sel_keys = new List<uint>();
                int i = 0;
                foreach (uint k in t.Keys)
                {
                    if (cmdlist[i] == cmd)
                    {
                        num_cort++;
                        sel_keys.Add(k);
                    }
                    i++;
                }

                arr = new string[num_atr, num_cort];
                i = 0;
                foreach (uint k in sel_keys)
                {
                    arr[0, i] = t[k].ID.ToString(); arr[1, i] = t[k].Name.ToString();
                    arr[2, i] = t[k].Position.ToString();
                    i++;
                }
            }
            if(sysItem is Projects)
            {
                Projects t = sysItem as Projects;

                int num_atr = 3, num_cort = 0;
                List<uint> sel_keys = new List<uint>();
                foreach (uint k in t.Keys)
                {
                    if (cmdlist[(int)k] == cmd)
                    {
                        num_cort++;
                        sel_keys.Add(k);
                    }
                }

                arr = new string[num_atr, num_cort];
                int i = 0;
                foreach (uint k in sel_keys)
                {
                    arr[0, i] = t[k].ID.ToString(); arr[1, i] = t[k].Name.ToString();
                    arr[2, i] = t[k].Description.ToString();
                    i++;
                }
            }

            return arr;
        }
        public static string[] GetPrimaryKeys(ISysItem sysItem, SQCommands cmd, List<SQCommands> cmdlist)
        {
            string[] pk = null;

            if (sysItem is Tasks)
            {
                Tasks t = sysItem as Tasks;

                int num_cort = 0;
                int i = 0;
                List<uint> sel_keys = new List<uint>();
                foreach (uint k in t.Keys)
                {
                    if (cmdlist[i] == cmd)
                    {
                        num_cort++;
                        sel_keys.Add(k);
                    }
                    i++;
                }

                pk = new string[num_cort];
                i = 0;
                foreach (uint k in sel_keys)
                {
                    pk[i] = t[k].ID.ToString();
                    i++;
                }
            }
            if (sysItem is Employees)
            {
                Employees t = sysItem as Employees;

                int num_cort = 0;
                List<uint> sel_keys = new List<uint>();
                int i = 0;
                foreach (uint k in t.Keys)
                {
                    if (cmdlist[i] == cmd)
                    {
                        num_cort++;
                        sel_keys.Add(k);
                    }
                    i++;
                }

                pk = new string[num_cort];
                i = 0;
                foreach (uint k in sel_keys)
                {
                    pk[i] = t[k].ID.ToString();
                    i++;
                }
            }
            if (sysItem is Projects)
            {
                Projects t = sysItem as Projects;

                int num_cort = 0;
                List<uint> sel_keys = new List<uint>();
                int i = 0;
                foreach (uint k in t.Keys)
                {
                    if (cmdlist[i] == cmd)
                    {
                        num_cort++;
                        sel_keys.Add(k);
                    }
                    i++;
                }

                pk = new string[num_cort];
                i = 0;
                foreach (uint k in sel_keys)
                {
                    pk[i] = t[k].ID.ToString();
                    i++;
                }
            }

            return pk;
        }
        public static void SetData(ref ISysItem sysItem, string[,] Arr)
        {
            if (Arr == null) return;
            if (sysItem is Tasks)
            {
                Task t;
                for(int i = 0; i < Arr.GetLength(1); i++)
                {
                    t = new Task(uint.Parse(Arr[0, i]), Arr[1, i], uint.Parse(Arr[2, i]),
                                 (TaskType)Enum.Parse(typeof(TaskType), Arr[3, i]),
                                 (TaskPriority)Enum.Parse(typeof(TaskPriority), Arr[4, i]), 
                                 uint.Parse(Arr[5, i]), uint.Parse(Arr[6, i]),
                                 (TaskStatus)Enum.Parse(typeof(TaskStatus), Arr[7, i]), 
                                 Arr[8, i]);
                    (sysItem as Tasks).AddItemByKey(t);
                }
            }
            if (sysItem is Employees)
            {
                Employee t;
                for (int i = 0; i < Arr.GetLength(1); i++)
                {
                    t = new Employee(uint.Parse(Arr[0, i]), Arr[1, i], (EmpPosition)Enum.Parse(typeof(EmpPosition), Arr[2, i]));
                    (sysItem as Employees).AddItemKey(t);
                }
            }
            if (sysItem is Projects)
            {
                Project t;
                for (int i = 0; i < Arr.GetLength(1); i++)
                {
                    t = new Project(uint.Parse(Arr[0, i]), Arr[1, i], Arr[2, i]);
                    (sysItem as Projects).AddItem(t);
                }
            }
        }
    }

    // Неверный формат файла источника данных 
    public class WrongFileFormatException : Exception
    {
        public WrongFileFormatException(string msg) : base(msg) { }
    }
}
