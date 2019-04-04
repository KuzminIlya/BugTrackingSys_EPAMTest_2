using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackingSys_EPAMTest_2
{
    // ТИПЫ
    // Тип, приоритет, статус задачи
    public enum TaskType { Task, Error, Improvement }; // Задача, ошибка, улучшение
    public enum TaskPriority { NotAssigned, Low, Medium, High, Critical }; // Не назначен, Низкий, Средний, Высокий, Критический   
    // Новая, В работе (решается), Решена, Не решена, На тестировании, Протестирована, Завершена, Отклонена 
    public enum TaskStatus { New, InProcess, Resolved, NotResolved, InTesting, Tested, Completed, Rejected  }
    // Должности сотрудников
    public enum EmpPosition { Head, Developer, Tester } // Руководитель, разработчик, тестировщик

    //  ЭЛЕМЕНТЫ СИСТЕМЫ
    // Задача
    public struct Task
    {
        public Task(uint id, string theme, uint projid, TaskType type, TaskPriority priority, uint addedemp, uint execemp, TaskStatus stat, string descr) : this()
        {
            ID = id;
            Theme = theme; ProjectID = projid; Type = type;
            Priority = priority; AddedEmployeeID = addedemp;
            ExecutorEmployeeID = execemp; Status = stat;
            Description = descr;
        }

        public uint ID { get; set; } // идентификатор задачи
        public string Theme { get; set; } // тема (название) задачи
        public uint ProjectID { get; set; } // проект (ссылка на проекты)
        public TaskType Type { get; set; } // Тип задачи
        public TaskPriority Priority { get; set; } // Приоритет
        public uint AddedEmployeeID { get; set; } // ID добавившего задачу пользователя (ссылка на сотрудников)
        public uint ExecutorEmployeeID { get; set; } // ID исполнителя (ссылка на сотрудников)
        public TaskStatus Status { get; set; } // Статус задачи (в соответствии с жизненным циклом)
        public string Description { get; set; } // Описание задачи
    }
    //Сотрудник
    public struct Employee
    {
        public Employee(uint id, string name, EmpPosition pos) : this()
        {
            ID = id;  Name = name; Position = pos;
        }

        public uint ID { get; set; } // идентификатор сотрудника
        public string Name { get; set; } // имя сотрудника
        public EmpPosition Position { get; set; } // должность сотрудника
    }
    // Проект
    public struct Project
    {
        public Project(uint id, string name, string descr) : this()
        {
            ID = id;
            Name = name;
            Description = descr;
        }

        public uint ID { get; set; } // идентификатор проекта
        public string Name { get; set; } // название проекта
        public string Description  { get; set; } // Описание проекта
    }
    // Объекты системы должны определять методы вставки, удаления и
    // изменения элементов 
    public interface ISysItem
    {
        void Insert(ISysItem item, List<ISysItem> linkeditems);
        void Update(ISysItem item, List<ISysItem> linkeditems);
        void Delete(ISysItem item, List<ISysItem> linkeditems);
    }

    // Список задач
    public class Tasks : ISysItem
    {
        protected Dictionary<uint, Task> tasks;

        public Tasks() => tasks = new Dictionary<uint, Task>();
        public Tasks(List<Task> tsklist) : this()
        {
            for (uint i = 0; i < tsklist.Count; i++)
                tasks.Add(i, tsklist[(int)i]);
        }
        public Tasks(Tasks new_tsk) : this() => tasks = new_tsk.tasks;

        public void AddItemByKey(Task item)
        {
            Tasks ins_tasks = new Tasks(new List<Task>() { item });
            foreach (uint key in ins_tasks.tasks.Keys)
            {
                tasks.Add(ins_tasks.tasks[key].ID, ins_tasks.tasks[key]);
            }
        }
        public void Insert(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null)
                throw new WrongItemException(string.Format("Вставка пустого элемента в список задач"));
            if (!(item is Tasks))
                throw new WrongItemException(string.Format("Вставка неверного элемента в список задач"));
            Tasks ins_task = item as Tasks;
            if (linkeditems == null)
            {
                Insert_Items(ins_task);
            }
            else
            {
                CheckLink(ins_task, linkeditems);
                Insert_Items(ins_task);
            }
            
        }
        public void Update(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список задач"));
            if (item is Tasks) new WrongItemException(string.Format("Вставка неверного элемента в список задач")); ;
            Tasks upd_task = item as Tasks;

            CheckPresent(upd_task);

            if (linkeditems == null)
            {
                Update_Items(upd_task);
            }
            else
            {
                CheckLink(upd_task, linkeditems);
                Update_Items(upd_task);
            }
        }
        public void Delete(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список задач"));
            if (item is Tasks) new WrongItemException(string.Format("Вставка неверного элемента в в список задач")); ;
            Tasks del_task = item as Tasks;

            CheckPresent(del_task);

            // Удаление
            foreach (uint key in del_task.tasks.Keys)
                foreach (uint k in tasks.Keys.ToArray())
                    if (tasks[k].ID == del_task.tasks[key].ID)
                        tasks.Remove(k);
        }
        protected void Insert_Items(Tasks ins_task)
        {
            uint i = 0;
            Task t;
            if (tasks.Count == 0)
            {
                foreach (uint key in ins_task.tasks.Keys)
                {
                    t = ins_task.tasks[key];
                    tasks.Add(i, t);
                    t.ID = i;
                    tasks[i] = t;
                    i++;
                }
            }
            else
            {
                i = tasks.Last().Key + 1;
                foreach (uint key in ins_task.tasks.Keys)
                {
                    t = ins_task.tasks[key];
                    tasks.Add(i, t);
                    t.ID = i;
                    tasks[i] = t;
                    i++;
                }
            }
        }
        protected void Update_Items(Tasks upd_task)
        {
            foreach (uint key in upd_task.tasks.Keys)
                foreach (uint k in tasks.Keys.ToArray())
                    if (tasks[k].ID == upd_task.tasks[key].ID)
                        tasks[k] = upd_task.tasks[key];
        }
        protected void CheckPresent(Tasks chk_item)
        {
            uint currID = 0;
            var test_taskId = from i in tasks.Keys where i == currID select i;
            foreach (uint key in chk_item.tasks.Keys)
            {
                currID = chk_item[key].ID;
                if (test_taskId.Count() == 0)
                    throw new LinkError("Задача не найдена в системе!");
            }
        }
        protected void CheckLink(Tasks chk_task, List<ISysItem> linkeditems)
        {
            Employees emp = null;
            Projects prj = null;
            foreach (ISysItem si in linkeditems)
            {
                if (si is Projects) prj = si as Projects;
                if (si is Employees) emp = si as Employees;
            }
            if (prj == null || emp == null)
                throw new WrongItemException(string.Format("Отсутствуют целевые объекты для списка задач!"));

            uint addemplID = 0, exempID = 0, prjid = 0;
            var test_addID = from i in emp.Keys where i == addemplID select i;
            var test_excID = from i in emp.Keys where i == exempID select i;
            var test_prjid = from i in prj.Keys where i == prjid select i;
            foreach (uint key in chk_task.tasks.Keys)
            {
                addemplID = chk_task[key].AddedEmployeeID;
                exempID = chk_task[key].ExecutorEmployeeID;
                prjid = chk_task[key].ProjectID;

                if (test_addID.Count() == 0 || test_excID.Count() == 0)
                    throw new LinkError(string.Format("Указанных сотрудников нет в системе!"));
                if (test_prjid.Count() == 0)
                    throw new LinkError(string.Format("Указанный проект отсутствует в системе!"));
            }
        }

        public Dictionary<uint, Task>.KeyCollection Keys => tasks.Keys;
        public Task this[uint key]
        {
            get { return tasks[key]; }
        }
    }
    // Список сотрудников
    public class Employees : ISysItem
    {
        protected Dictionary<uint, Employee> employees;

        public Employees()
        {
            employees = new Dictionary<uint, Employee>();
        }
        public Employees(List<Employee> emplist) : this()
        {
            for (uint i = 0; i < emplist.Count; i++)
                employees.Add(i, emplist[(int)i]);
        }
        public Employees(Employee emp) : this(new List<Employee>() { emp }) { }
        public Employees(Employees new_emp) : this() => employees = new_emp.employees;

        public void Insert(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список сотрудников!"));
            if (!(item is Employees)) throw new WrongItemException(string.Format("Вставка неверного элемента в список сотрудников!"));
            Employees ins_emp = item as Employees;
            uint i = 0;
            Employee t;
            if (employees.Count == 0)
            {
                foreach (uint key in ins_emp.employees.Keys)
                {
                    t = ins_emp.employees[key];
                    employees.Add(i, t);
                    t.ID = i;
                    employees[i] = t;
                    i++;
                }
            }
            else
            {
                i = employees.Last().Key + 1;
                foreach (uint key in ins_emp.employees.Keys)
                {
                    t = ins_emp.employees[key];
                    employees.Add(i, t);
                    t.ID = i;
                    employees[i] = t;
                    i++;
                }
            }
        }
        public void Update(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список сотрудников!"));
            if (!(item is Employees)) throw new WrongItemException(string.Format("Вставка неверного элемента в список сотрудников!"));
            Employees upd_emp = item as Employees;
            check_item(upd_emp);
            update_items(upd_emp);
        }
        public void Delete(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список сотрудников!"));
            if (!(item is Employees)) throw new WrongItemException(string.Format("Вставка неверного элемента в список сотрудников!"));
            Employees del_emp = item as Employees;
            check_item(del_emp);

            if (linkeditems == null)
            {
                delete_item(del_emp);
            }
            else
            {
                CheckLink(del_emp, linkeditems);
                delete_item(del_emp);
            }
        }
        public void AddItem(Employee item)
        {
            Employees ins_emp = new Employees(new List<Employee>() { item });

            Insert(new Employees(new List<Employee>() { item }), null);
        }
        public void AddItemKey(Employee item)
        {
            insert_items_keys(new Employees(new List<Employee>() { item }));
        }
        protected void insert_items_keys(Employees ins_task)
        {
            Employee t;
            foreach (uint key in ins_task.employees.Keys)
            {
                t = ins_task.employees[key];
                if (employees.Any())
                    employees.Add(ins_task.employees[key].ID, t);
                else
                    employees.Add(0, t);
            }
        }
        protected void update_items(Employees upd_emp)
        {
            foreach (uint key in upd_emp.employees.Keys)
                foreach (uint k in employees.Keys.ToArray())
                    if (employees[k].ID == upd_emp.employees[key].ID)
                        employees[k] = upd_emp.employees[key];
        }
        protected void delete_item(Employees del_emp)
        {
            foreach(uint key in del_emp.Keys)
            {
                employees.Remove(del_emp[key].ID);
            }
        }
        protected void check_item(Employees upd_emp)
        {
            uint currID = 0;
            var test_taskId = from i in employees.Keys where i == currID select i;
            foreach (uint key in upd_emp.employees.Keys)
            {
                currID = upd_emp[key].ID;
                if (!test_taskId.Any()) throw new LinkError("Сотрудник не найден в системе!");
            }
        }
        protected void CheckLink(Employees chk_emp, List<ISysItem> linkeditems)
        {
            foreach (ISysItem si in linkeditems)
                if (si == null) throw new WrongItemException(string.Format("Использование пустого списка ссылок в списке сотрудников"));

            Tasks tasks = linkeditems[0] as Tasks;
            if (tasks == null) throw new WrongItemException(string.Format("Использование неверной ссылки в списке ссылок для списка сотрудников"));

            foreach (uint k in chk_emp.Keys)
            {
                foreach (uint key in tasks.Keys)
                    if (chk_emp[k].ID == tasks[key].AddedEmployeeID ||
                        chk_emp[k].ID == tasks[key].ExecutorEmployeeID)
                        throw new LinkError("Удаляемый сотрудник присутствует в списке задач!");
            }
        }

        public Employee this[uint key]
        {
            get
            {
                return employees[key];
            }
        }
        public Dictionary<uint, Employee>.KeyCollection Keys => employees.Keys;
    }
    // Список проектов
    public class Projects : ISysItem
    {
        protected Dictionary<uint, Project> projects;

        public Projects()
        {
            projects = new Dictionary<uint, Project>();
        }
        public Projects(List<Project> prjlist) : this()
        {
            for (uint i = 0; i < prjlist.Count; i++)
                projects.Add(i, prjlist[(int)i]);
        }
        public Projects(Projects new_prj) : this() => projects = new_prj.projects;

        public void Insert(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список проектов!"));
            if (!(item is Projects)) throw new WrongItemException(string.Format("Вставка неверного элемента в список проектов!"));
            Projects ins_prj = item as Projects;
            Insert_Items_Autoinc(ins_prj);
        }
        public void Update(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список проектов!"));
            if (!(item is Projects)) throw new WrongItemException(string.Format("Вставка неверного элемента в список проектов!"));
            Projects upd_prj = item as Projects;
            Check_Item(upd_prj);
            Update_Items(upd_prj);
        }
        public void Delete(ISysItem item, List<ISysItem> linkeditems)
        {
            if (item == null) throw new WrongItemException(string.Format("Вставка пустого элемента в список проектов!"));
            if (!(item is Projects)) throw new WrongItemException(string.Format("Вставка неверного элемента в список проектов!"));
            Projects del_prj = item as Projects;
            Check_Item(del_prj);

            if (linkeditems == null)
            {
                Delete_Item(del_prj);
            }
            else
            {
                CheckLink(del_prj, linkeditems);
                Delete_Item(del_prj);
            }
        }

        public void AddItem(Project item)
        {
            Insert_Items(new Projects(new List<Project>() { item }));
        }
        protected void Insert_Items_Autoinc(Projects ins_prj)
        {
            uint i = 0;
            Project t;
            if (projects.Count == 0)
            {
                foreach (uint key in ins_prj.projects.Keys)
                {
                    t = ins_prj.projects[key];
                    projects.Add(i, t);
                    t.ID = i;
                    projects[i] = t;
                    i++;
                }
            }
            else
            {
                i = projects.Last().Key + 1;
                foreach (uint key in ins_prj.projects.Keys)
                {
                    t = ins_prj.projects[key];
                    projects.Add(i, t);
                    t.ID = i;
                    projects[i] = t;
                    i++;
                }
            }
        }
        protected void Insert_Items(Projects ins_task)
        {
            Project t;
            foreach (uint key in ins_task.projects.Keys)
            {
                t = ins_task.projects[key];
                if (projects.Any())
                    projects.Add(ins_task.projects[key].ID, t);
                else
                    projects.Add(0, t);
            }
        }
        protected void Update_Items(Projects upd_prj)
        {
            foreach (uint key in upd_prj.projects.Keys)
                foreach (uint k in projects.Keys.ToArray())
                    if (projects[k].ID == upd_prj.projects[key].ID)
                        projects[k] = upd_prj.projects[key];
        }
        protected void Delete_Item(Projects del_prj)
        {
            foreach (uint key in del_prj.Keys)
            {
                projects.Remove(del_prj[key].ID);
            }
        }
        protected void Check_Item(Projects upd_prj)
        {
            uint currID = 0;
            var test_taskId = from i in projects.Keys where i == currID select i;
            foreach (uint key in upd_prj.projects.Keys)
            {
                currID = upd_prj[key].ID;
                if (!test_taskId.Any()) throw new LinkError("Проект не найден в списке проектов!");
            }
        }
        protected void CheckLink(Projects chk_prj, List<ISysItem> linkeditems)
        {
            foreach (ISysItem si in linkeditems)
                if (si == null) throw new WrongItemException(string.Format("Использование пустого списка ссылок в списке проектов"));

            Tasks tasks = linkeditems[0] as Tasks;
            if (tasks == null) throw new WrongItemException(string.Format("Использование неверного списка ссылок в списке проектов"));

            foreach (uint k in chk_prj.Keys)
            {
                foreach (uint key in tasks.Keys)
                    if (chk_prj[k].ID == tasks[key].ProjectID)
                        throw new LinkError("Удаляемый проект присутствует в списке задач!");
            }
        }

        public Project this[uint key]
        {
            get
            {
                return projects[key];
            }
        }
        public Dictionary<uint, Project>.KeyCollection Keys => projects.Keys;
    }

    // СИСТЕМА
    public class BTSystem
    {
        public Employee currentEmployee { get; set; }
        public Tasks tasks { get; }
        public Employees employees { get; }
        public Projects projects { get; }

        public BTSystem(ISysItem tsk, ISysItem proj, ISysItem emp)
        {
            tasks = new Tasks(tsk as Tasks);
            employees = new Employees(emp as Employees);
            projects = new Projects(proj as Projects);
        }

        public void Insert(ISysItem item)
        {
            // Вставка элемента
            if (item is Tasks)
            {
                Tasks itm = item as Tasks;
                foreach (uint key in itm.Keys)
                {
                    if (itm[key].AddedEmployeeID != currentEmployee.ID)
                        throw new BTSystemException("Добавившим задачу сотрудником может быть только текущий пользователь!");

                    if (currentEmployee.Position == EmpPosition.Head)
                    {
                        if (itm[key].Status == TaskStatus.InProcess && employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Developer)
                            throw new BTSystemException("Задачу со статусом \'В работе\' можно адресовать только разработчику");
                        if (itm[key].Status == TaskStatus.InTesting && employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Tester)
                            throw new BTSystemException("Задачу со статусом \'На тестировании\' можно адресовать только тестировщику");
                        if (itm[key].Status == TaskStatus.New && employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Head)
                            throw new BTSystemException("Задачу со статусом \'Новый\' можно адресовать только руководителю");
                        if (itm[key].Status == TaskStatus.New || itm[key].Status == TaskStatus.NotResolved || 
                            itm[key].Status == TaskStatus.Resolved || itm[key].Status == TaskStatus.Tested)
                            throw new BTSystemException("Данный статус задаче может назначить только разработчик или тестировщик");
                    }
                    else
                    {
                        if (itm[key].Type == TaskType.Task)
                            throw new BTSystemException("Задачи типа \'Задача\' может создавать только руководитель");
                        if (itm[key].Priority != TaskPriority.NotAssigned)
                            throw new BTSystemException("Приоритет задаче назначается руководителем");
                        if (employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Head)
                            throw new BTSystemException("Разработчик или тестировщик могут адресовать задачу только руководителю");
                        if (itm[key].Status != TaskStatus.New)
                            throw new BTSystemException("При создании новой задачи разработчик или тестировщик могут назначать задаче только статус \'Новый\'");
                    }
                }
                tasks.Insert(item, new List<ISysItem> { employees, projects });
            }
            if (item is Employees)
            {
                if (currentEmployee.Position != EmpPosition.Head)
                    throw new AccessRightsException(string.Format("Вы не можете добавлять новых сотрудников!"));
                employees.Insert(item, null);
            }
            if (item is Projects)
            {
                if (currentEmployee.Position != EmpPosition.Head)
                    throw new AccessRightsException(string.Format("Вы не можете добавлять новые проекты!"));
                projects.Insert(item, null);
            }
        }
        public void Delete(ISysItem item)
        {
            // Удаление элементов
            if (currentEmployee.Position != EmpPosition.Head)
                throw new AccessRightsException(string.Format("Вы не можете удалять элементы из системы!"));
            if (item is Tasks) tasks.Delete(item, null);
            if (item is Employees) employees.Delete(item, new List<ISysItem> { tasks });
            if (item is Projects) projects.Delete(item, new List<ISysItem> { tasks });
        }
        public void Update(ISysItem item)
        {
            // Изменение элементов
            if (item is Tasks)
            {
                Tasks itm = item as Tasks;
                foreach (uint key in itm.Keys)
                {
                    uint currexecutor = tasks[itm[key].ID].ExecutorEmployeeID;
                    if(currexecutor != currentEmployee.ID)
                        throw new BTSystemException("Вы не можете изменять задачи, адресованные не вам!");
                    if (itm[key].AddedEmployeeID != tasks[itm[key].ID].AddedEmployeeID)
                        throw new BTSystemException("Нельзя менять поле: \'Добавил\'");
                    if (currentEmployee.Position == EmpPosition.Head)
                    {
                        if (itm[key].Status != tasks[itm[key].ID].Status)
                        {
                            if (itm[key].Status == TaskStatus.InProcess && employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Developer)
                                throw new BTSystemException("Задачу со статусом \'В работе\' можно адресовать только разработчику");
                            if (itm[key].Status == TaskStatus.InTesting && employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Tester)
                                throw new BTSystemException("Задачу со статусом \'На тестировании\' можно адресовать только тестировщику");
                            if (itm[key].Status == TaskStatus.New && employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Head)
                                throw new BTSystemException("Задачу со статусом \'Новый\' можно адресовать только руководителю");
                            if (itm[key].Status == TaskStatus.NotResolved || itm[key].Status == TaskStatus.Resolved || itm[key].Status == TaskStatus.Tested)
                                throw new BTSystemException("Данный статус задаче может назначить только разработчик или тестировщик");
                        }
                    }
                    else
                    {
                        if (itm[key].AddedEmployeeID != tasks[itm[key].ID].AddedEmployeeID ||
                            itm[key].ProjectID != tasks[itm[key].ID].ProjectID ||
                            itm[key].Type != tasks[itm[key].ID].Type ||
                            itm[key].Priority != tasks[itm[key].ID].Priority)
                            throw new BTSystemException("Поля: \'Добавил\', \'Проект\', \'Тип\', \'Приоритет\' недоступны для изменения данному пользователю");

                        if (currentEmployee.Position == EmpPosition.Developer)
                        {
                            if (itm[key].Status != tasks[itm[key].ID].Status)
                                if (itm[key].Status != TaskStatus.Resolved)
                                    throw new BTSystemException("Разработчик может менять статус задачи только на \'Решена\'");
                                else if (employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Head)
                                    throw new BTSystemException("Разработчик может адресовать задачу только руководителю");
                        }
                        if (currentEmployee.Position == EmpPosition.Tester)
                        {
                            if (itm[key].Status != tasks[itm[key].ID].Status)
                                if (itm[key].Status != TaskStatus.Tested && itm[key].Status != TaskStatus.NotResolved)
                                    throw new BTSystemException("Тестировщик может менять статус задачи только на \'Не решена\' или \'Протестирована\'");
                                else if (employees[itm[key].ExecutorEmployeeID].Position != EmpPosition.Head)
                                    throw new BTSystemException("Тестировщик может адресовать задачу только руководителю");
                        }
                    }
                }
                tasks.Update(item, new List<ISysItem> { employees, projects });
            }
            if (item is Employees)
            {
                if (currentEmployee.Position != EmpPosition.Head)
                    throw new AccessRightsException(string.Format("Вы не можете изменять сотрудников в системе!"));
                employees.Update(item, new List<ISysItem> { tasks });
            }
            if (item is Projects)
            {
                if (currentEmployee.Position != EmpPosition.Head)
                    throw new AccessRightsException(string.Format("Вы не можете изменять проекты в системе!"));
                projects.Update(item, new List<ISysItem> { tasks });
            }
        }
    }

    // ИСКЛЮЧЕНИЯ
    public class WrongItemException : Exception
    {
        public WrongItemException(string mess) : base(mess) { }
    }
    public class LinkError : Exception
    {
        public LinkError(string mess) : base(mess) { }
    }
    public class AccessRightsException : Exception
    {
        public AccessRightsException(string mess) : base(mess) { }
    }
    public class BTSystemException : Exception
    {
        public BTSystemException(string mess) : base(mess) { }
    }


}
